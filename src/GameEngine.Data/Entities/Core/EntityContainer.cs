using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.Common;

namespace GameEngine.Data.Entities.Core {
	public class EntityContainer : IEncodable {

		private List<EntityTemplate> Templates;

		public EntityContainer() {
			Templates = new List<EntityTemplate>();
		}

		public void Add(EntityTemplate template) {
			this.Templates.Add(template);
		}

		public void Remove(int id) {
			Templates.Remove(Templates.FirstOrDefault(template => template.ID == id));
		}

		public void Remove(EntityTemplate template) {
			Templates.Remove(template);
		}

		public void RemoveAt(int index) {
			Templates.RemoveAt(index);
		}

		public void Clear() {
			Templates.Clear();
		}

		public EntityTemplate Get(int id) {
			return Templates.FirstOrDefault(t => t.ID == id);
		}

		public EntityTemplate GetAt(int index) {
			return Templates[index];
		}

		public List<EntityTemplate> All() {
			return this.Templates.ToList();
		}

		public List<EntityTemplate> GetBuildings() {
			return Templates.Where(t => t.EntityType == EntityType.Building).ToList();
		}

		public List<EntityTemplate> GetDoors() {
			return Templates.Where(t => t.EntityType == EntityType.Door).ToList();
		}
		
		public List<EntityTemplate> GetNpcs() {
			return Templates.Where(t => t.EntityType == EntityType.Npc).ToList();
		}

		public List<EntityTemplate> GetPlayers() {
			return Templates.Where(t => t.EntityType == EntityType.Player).ToList();
		}
		
		public List<EntityTemplate> GetWarpfield() {
			return Templates.Where(t => t.EntityType == EntityType.Warpfield).ToList();
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(Templates.Count);
			foreach (EntityTemplate ob in Templates) {
				stream.Write(ob);
			}
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			int count = stream.ReadInt32();
			for (int i = 0; i < count; i++) {
				Templates.Add(stream.ReadObject<EntityTemplate>());
			}
			return this;
		}
	}
}
