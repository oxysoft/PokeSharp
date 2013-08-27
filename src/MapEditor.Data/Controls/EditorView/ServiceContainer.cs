using System;
using System.Collections.Generic;

namespace MapEditor.Data.Controls.EditorView {
	public class ServiceContainer : IServiceProvider {
		#region Constructors
		public ServiceContainer() {
			this.services = new Dictionary<Type, object>();
		}
		#endregion

		#region Fields
		private Dictionary<Type, object> services;
		#endregion

		#region IServiceProvider Member
		public void AddService<T>(T service) {
			services.Add(typeof(T), service);
		}
		public object GetService(Type serviceType) {
			object service;
			services.TryGetValue(serviceType, out service);

			return service;
		}
		#endregion
	}
}
