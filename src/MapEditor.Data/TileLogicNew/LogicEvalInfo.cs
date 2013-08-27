namespace MapEditor.Data.TileLogicNew {
	public class LogicEvalInfo {
		public string s1;
		public int s2;

		public LogicEvalInfo(string s1, int s2) {
			this.s1 = s1;
			this.s2 = s2;
		}

		public void Adjust(string s0, int s1, int s2) {
			this.s1 = s0;
			this.s2 = EditorEngine.Instance.GetTilesetByName(s0).Texture.GetIndex(s1, s2);
		}

		public void Adjust(string s1, int s2) {
			this.s1 = s1;
			this.s2 = s2;
		}

		public static LogicEvalInfo Create(string s1, int s2) {
			return new LogicEvalInfo(s1, s2);
		}
	}
}
