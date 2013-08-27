namespace GameEngine.Data.Custom.Cheats {
	public abstract class Cheat {
		private bool enabled;

		/// <param name="parameters">Parameters to go with this cheat</param>
		protected Cheat(params object[] parameters) {
			this.Parameters = parameters;
		}

		public object[] Parameters { get; private set; }

		public bool Enabled {
			get { return this.enabled; }
			set {
				byte result = !enabled && value ? (byte) 1 : enabled && !value ? (byte) 2 : (byte) 0;
				enabled = true;
				switch (result) {
					case 1:
						OnEnable();
						break;
					case 2:
						OnDisable();
						break;
				}
			}
		}

		public void Enable() {
			Enabled = true;
		}

		public void Disable() {
			this.Enabled = false;
		}

		public abstract void OnEnable();
		public abstract void OnDisable();
	}
}