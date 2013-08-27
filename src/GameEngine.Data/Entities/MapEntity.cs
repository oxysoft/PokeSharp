using System;
using System.Linq;
using Editor.Selections;
using GameEngine.Data.Common;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Entities.World;
using General.Common;
using General.Encoding;
using General.Graphics.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Entities {
	[Serializable]
	public class MapEntity : Entity, IAnimationContainer {
		public MapEntity(IRegionEntityFactory factory, Map map, bool ScrollAffected) : this(factory, ScrollAffected) {
			this.Map = map;
		}

		public MapEntity(IRegionEntityFactory factory, bool cameraAffected)
			: base(factory) {
			this.World = factory.World;
			this.Collidable = true;
			this.CameraAffected = cameraAffected;

			this.blendstate = BlendState.NonPremultiplied;
			this.Opacity = 1.0f;
			this.Scale = 1.0f;

			this.Shadow = true;
			this.Color = Color.White;

			Initialize();
		}

		public Common.World World;
		public Map Map;
		public BlendState blendstate;
		public Animator Animator;

		public EntityTemplate Template {
			get { return World.EntityContainer.Get(TemplateID); }
		}

		public bool Collidable, CameraAffected;

		public bool Visible {
			get { return Opacity > 0; }
		}

		public Vector2 Scroll {
			get {
				if (!CameraAffected) return Vector2.Zero;
				return World.Camera.Location;
			}
		}

		public virtual Vector2 Origin {
			get { return new Vector2(Width / 2f, Height / 2f); }
		}

		public override int Width {
			get {
				if (Template.Texture.Texture != null) {
					return Template.Texture.FrameWidth;
				}
				return 0;
			}
		}

		public override int Height {
			get {
				if (Template.Texture.Texture != null) {
					return Template.Texture.FrameHeight;
				}
				return 0;
			}
		}

		public int TemplateID;
		public float Rotation, Opacity, Scale;
		public bool Shadow;

		public bool TopMost;
		public Color Color;

		private int fadeDirection;
		private float fadeTime = 0.2f;

		public void FadeOut() {
			this.fadeTime = 0.2f;
			this.fadeDirection = -1;
		}

		public void FadeIn() {
			this.fadeTime = 0.2f;
			this.fadeDirection = 1;
		}

		public void FadeOut(float time) {
			this.fadeTime = time;
			this.fadeDirection = -1;
		}

		public void FadeIn(float time) {
			this.fadeTime = time;
			this.fadeDirection = 1;
		}

		public void Show() {
			this.Opacity = 1.0f;
		}

		public void Hide() {
			this.Opacity = 0.0f;
		}

		public void Initialize() {
			if (Animator == null) {
				Animator = new Animator(this);
			}
		}

		public Animation GetAnimation(string name) {
			return Template.Animations.FirstOrDefault(a => a.Name == name);
		}

		public virtual void DrawShadow(GameTime time) {
			Initialize();

			if (this.Template.initialized) {
				SpriteBatch batch = World.ViewData.SpriteBatch;

				Vector2 pos = Position + new Vector2(0, Template.ShadowOffset) + Scroll;
				Rectangle src = Template.Texture.GetSource(this.Animator.AnimationIndex);
				Rectangle target = new Rectangle((int) pos.X, (int) pos.Y, Template.Texture.FrameWidth, (int) (Template.Texture.FrameHeight * 0.6f));

				Shadow = true;

				if (this.Shadow) {
					switch (Template.ShadowType) {
						case ShadowType.Perspective:
							batch.Draw(Template.Texture.Texture, target, src, new Color(0f, 0f, 0f, 0.3f), 0.0f, Vector2.Zero, SpriteEffects.FlipVertically, 0f);
							break;
					}
				}
			}
		}

		public void BeginDrawAnew(GameTime gameTime) {
			SpriteBatch spriteBatch = World.ViewData.SpriteBatch;
			spriteBatch.End();
			BeginDraw(gameTime);
		}

		public void BeginDraw(GameTime gameTime) {
			SpriteBatch spriteBatch = World.ViewData.SpriteBatch;

			spriteBatch.Begin(
				SpriteSortMode.Deferred,
				blendstate,
				SamplerState.PointClamp,
				null, null, null);
		}

		public void EndDraw(GameTime gameTime) {
			SpriteBatch spriteBatch = World.ViewData.SpriteBatch;
			spriteBatch.End();
		}

		public override void Update(GameTime gameTime) {
			float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;
			this.Opacity += this.fadeDirection * elapsed / this.fadeTime;

			this.Initialize();

			if (this.Opacity >= 1) {
				this.Opacity = 1f;
				this.fadeDirection = 0;
			}
			if (this.Opacity <= 0) {
				this.Opacity = 0f;
				this.fadeDirection = 0;
			}

			this.Animator.Update(gameTime);
			base.Update(gameTime);

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime) {
			this.Initialize();
			base.Draw(gameTime);
			/*foreach (Rectangle col in Template.CollisionMap) {
				SelectionUtil.AutoWorkSpriteBatch = false;
				Rectangle dst = new Rectangle((int) (Position.X + Location.X + 16), (int) (Position.Y + Location.Y + 16), col.Width << 4, col.Height << 4);
				SelectionUtil.FillRectangle(World.ViewData.SpriteBatch, Color.Red * 0.5f, dst);
				SelectionUtil.AutoWorkSpriteBatch = true;
			}*/
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);

			stream.Write(TemplateID);
			stream.Write(Collidable);

			stream.Write(Shadow);

			stream.Write(Rotation);
			stream.Write(Scale);
			stream.Write(Opacity);

			stream.Write(TopMost);
			stream.Write(Color.ToVector4());
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);

			TemplateID = stream.ReadInt32();
			Collidable = stream.ReadBoolean();

			Shadow = stream.ReadBoolean();

			Rotation = stream.ReadSingle();
			Scale = stream.ReadSingle();
			Opacity = stream.ReadSingle();

			TopMost = stream.ReadBoolean();
			Color = new Color(stream.ReadVector4());

			return this;
		}
	}
}