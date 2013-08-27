using System.Collections.Generic;
using GameEngine.Data.Entities.Collision;
using GameEngine.Data.Entities.Types;
using GameEngine.Data.Entities.World;
using GameEngine.Data.Tiles;
using General.Common;
using General.Encoding;
using General.Graphics;
using General.Graphics.Animations;

namespace GameEngine.Data.Entities.Core {
	public class EntityTemplate : IEncodable {
		public int ID;
		public int ShadowOffset;
		public TileableTexture Texture;
		public EntityType EntityType;

		public bool initialized;
		public bool isSubEntity;
		public string Name;
		public ShadowType ShadowType;

		public List<Animation> Animations;

		public EntityTemplate() {
			Name = string.Empty;
			CollisionMap = new CollisionMap();
			Animations = new List<Animation>();
		}

		public EntityTemplate(EntityTemplateFactory factory) : this() {
			this.ID = factory.AllocateID();
		}

		public EntityTemplate(string name, EntityTemplateFactory factory) : this(factory) {
			this.Name = name;
		}

		public CollisionMap CollisionMap { get; set; }

		public void Encode(BinaryOutput stream) {
			stream.Write(Name);
			stream.Write(ID);

			stream.Write((byte) EntityType);
			stream.Write((byte) ShadowType);

			stream.Write(isSubEntity);

			stream.Write(ShadowOffset);
			stream.Write(0);

			stream.Write(CollisionMap as IEncodable);
			stream.Write(Texture);

			stream.Write(Animations.Count);
			foreach (Animation animation in Animations) {
				stream.Write(animation);
			}
		}

		public IEncodable Decode(BinaryInput stream) {
			Name = stream.ReadString();
			ID = stream.ReadInt32();

			EntityType = (EntityType) stream.ReadByte();
			ShadowType = (ShadowType) stream.ReadByte();

			ShadowType = ShadowType.Perspective;

			isSubEntity = stream.ReadBoolean();

			ShadowOffset = stream.ReadInt32();
			stream.ReadInt32();

			CollisionMap = stream.ReadObject<CollisionMap>();
			Texture = stream.ReadObject<TileableTexture>();

			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				Animations.Add(stream.ReadObject<Animation>());
			}
			return this;
		}

		public MapEntity CreateEntity(IRegionEntityFactory factory) {
			return CreateEntity(factory, true);
		}

		public MapEntity CreateEntity(IRegionEntityFactory factory, bool scrollAffected) {
			return CreateEntity(factory, factory.World, scrollAffected);
		}

		public MapEntity CreateEntity(IRegionEntityFactory factory, IResourceContainer resources, bool scrollAffected) {
			MapEntity result = null;

			switch (EntityType) {
				case EntityType.None:
					result = new MapEntity(factory, scrollAffected);
					break;
				case EntityType.Building:
					result = new BuildingEntity(factory, scrollAffected);
					break;
				case EntityType.Player:
					result = new PlayerEntity(factory, scrollAffected);
					break;
				case EntityType.Npc:
					result = new NPCEntity(factory, scrollAffected);
					break;
				case EntityType.Door:
					//result = new EntityDoor();
					break;
			}

			if (result != null) result.TemplateID = this.ID;
			return result;
		}
	}
}