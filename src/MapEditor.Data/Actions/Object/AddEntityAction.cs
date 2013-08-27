using System;
using GameEngine.Data.Common;
using GameEngine.Data.Entities;
using GameEngine.Data.Entities.Core;
using General.Common;
using Microsoft.Xna.Framework;

namespace MapEditor.Data.Actions.Object {
	public class AddEntityAction : IAction, IEncodable {
		
		public AddEntityAction() {
			this.entityIndex = -1;
		}

		public AddEntityAction(EntityTemplate model, Vector2 position)
			: this() {
			this.model = model;
			this.position = position;

			Map map = EditorEngine.Instance.CurrentMap;

			this.worldEntity = model.CreateEntity(map.Factory);
			this.worldEntity.Position = position * new Vector2(16, 16);
		}

		private EntityTemplate model;
		private Vector2 position;

		private string modelName;
		private int entityIndex;

		public MapEntity worldEntity;

		public string Title {
			get {
				return "Entity Add";
			}
		}

		public DateTime Date {
			get;
			set;
		}

		public void Execute() {
			Map map = EditorEngine.Instance.CurrentMap;
			this.modelName = model.Name;

			if (this.entityIndex < 0) {
				this.entityIndex = map.Entities.Count;
			}

			map.Entities.Insert(entityIndex, worldEntity);
		}

		public void UnExecute() {
			Map map = EditorEngine.Instance.CurrentMap;
			map.Entities.Remove(worldEntity);
		}

		public string Name {
			get {
				return "Entity Add";
			}
		}

		public DateTime Time {
			get;
			set;
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(position);
			stream.Write(model.Name);
			stream.Write(entityIndex);

			EntityIO writer = new EntityIO(stream, null, true);
			writer.Write(worldEntity);
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			position = stream.ReadVector2();
			modelName = stream.ReadString();
			entityIndex = stream.ReadInt32();
			
			if (!string.IsNullOrEmpty(modelName)) {
				World world = EditorEngine.Instance.World;
				model = EditorEngine.Instance.GetModelByName(modelName);
			}

			EntityIO io = new EntityIO(stream, EditorEngine.Instance.CurrentMap.Factory, true);
			this.worldEntity = io.Read();

			return this;
		}
	}
}
