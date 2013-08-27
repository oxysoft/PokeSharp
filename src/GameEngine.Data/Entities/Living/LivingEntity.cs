using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GameEngine.Data.Common;
using GameEngine.Data.Entities.Living.Core;
using GameEngine.Data.Entities.Living.Effects;
using GameEngine.Data.Entities.World;
using GameEngine.Data.Tiles;
using General.Common;
using General.Encoding;
using General.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Entities.Living {
	public class LivingEntity : MapEntity, ILiving {
		public LivingController Controller;
		public MovementSpeed MovementSpeed;
		public MovementState MovementState;
		public Facing Facing;
		public List<IEffect> Effects;
		protected bool movedLastFrame;
		protected Vector2 movement;

		public bool Locked {
			get { return Effects.Any(effect => effect is LockEffect && effect.Alive); }
		}

		public LivingEntity(IRegionEntityFactory factory, bool cameraAffected) : base(factory, cameraAffected) {
			this.Effects = new List<IEffect>();
		}

		public bool Movable {
			get { return MovementState == MovementState.None && !Locked && !Turning; }
		}

		public bool Turning { get; private set; }

		public override Vector2 Origin {
			get { return new Vector2(this.Width / 2 - 16 / 2, this.Height - 16); }
		}

		public Vector2 AbsolutePosition {
			get { return Position + movement; }
		}

		public virtual bool CanRun {
			get { return false; }
		}

		public event EventHandler<RequestingMoveArgs> RequestingMove;

		public event EventHandler BeginMoving;
		public event EventHandler Moving;
		public event EventHandler EndMoving;

		public event EventHandler<FacingChangedArgs> FacingChanged;
		public event EventHandler Warping;

		public event EventHandler Locking;
		public event EventHandler Released;

		public override void Update(GameTime gameTime) {
			base.Update(gameTime);

			if (Controller != null) Controller.Update(gameTime);

			if (!movedLastFrame && MovementState == MovementState.None) {
				Face(Facing);
			}

			if (movement != Vector2.Zero) {
				Vector2 facing = Facing.ToVector2();
				float speed = this.MovementSpeed.GetSpeed();
				float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;

				this.movement += facing * speed * elapsed;

				if (this.movement.X < 0 && this.Facing == Facing.Left) this.movement.X = 0;
				if (this.movement.X > 0 && this.Facing == Facing.Right) this.movement.X = 0;
				if (this.movement.Y < 0 && this.Facing == Facing.Up) this.movement.Y = 0;
				if (this.movement.Y > 0 && this.Facing == Facing.Down) this.movement.Y = 0;

				movedLastFrame = true;
				this.Moving.SafeInvoke(this, EventArgs.Empty);

				if (movement == Vector2.Zero) {
					movedLastFrame = false;
					this.MovementState = MovementState.None;
					EndMoving.SafeInvoke(this, EventArgs.Empty);
				}
			}

			for (int i = 0; i < Effects.Count; i++) {
				IEffect effect = Effects[i];
				if (!effect.Alive) Effects.RemoveAt(i--);
				effect.Update(gameTime);
			}
		}

		public override void DrawShadow(GameTime gameTime) {
			Initialize();

			if (this.Template.initialized) {
				SpriteBatch batch = World.ViewData.SpriteBatch;

				Vector2 pos = AbsolutePosition + new Vector2(0, Template.ShadowOffset) + Scroll;
				Rectangle src = Template.Texture.GetSource(this.Animator.AnimationIndex);
				Rectangle target = new Rectangle((int) pos.X, (int) pos.Y, Template.Texture.FrameWidth, (int) (Template.Texture.FrameHeight * 0.6f));

				Shadow = true;

				batch.Draw(Template.Texture.Texture, target, src, new Color(0f, 0f, 0f, 0.3f), 0.0f, Origin, SpriteEffects.FlipVertically, 0f);
				if (this.Shadow) {
					switch (Template.ShadowType) {
						case ShadowType.Perspective:
							break;
					}
				}
			}
		}

		public override void Draw(GameTime gameTime) {
			base.Initialize();

			SpriteBatch spriteBatch = this.World.ViewData.SpriteBatch;

			//safe
			Vector3 color = this.Color.ToVector3();
			Rectangle src = this.Template.Texture.GetSource(this.Animator.AnimationIndex);
			Rectangle dst = new Rectangle(
				(int) (this.AbsolutePosition.X + Scroll.X),
				(int) (this.AbsolutePosition.Y + Scroll.Y),
				(int) (this.Width * this.Scale),
				(int) (this.Height * this.Scale));

			DrawShadow(gameTime);

			spriteBatch.Draw(
				this.Template.Texture.Texture,
				dst,
				src,
				new Color(color.X, color.Y, color.Z, this.Opacity),
				this.Rotation, Origin, SpriteEffects.None, 0);

			base.Draw(gameTime);
		}

		public virtual void TryMove(Facing dir, MovementSpeed speed) {
			if (Movable) {
				RequestingMove.SafeInvoke(this, new RequestingMoveArgs(dir, speed));

				if (CanMove(dir)) {
					ForceMove(dir, speed);
				} else {
					Face(dir);
					Lock(GetAnimation("walking-up").TimePerFrame * ((GetAnimation("walking-up").Indices.Count - 1) / 2));
					switch (dir) {
						case Facing.Up:
							Animator.Play("walking-up");
							break;
						case Facing.Down:
							Animator.Play("walking-down");
							break;
						case Facing.Left:
							Animator.Play("walking-left");
							break;
						case Facing.Right:
							Animator.Play("walking-right");
							break;
					}
				}
			}
		}

		public virtual void ForceMove(Facing dir, MovementSpeed speed) {
			if (MovementState == MovementState.None) {
				this.Initialize();
				BeginMoving.SafeInvoke(this, EventArgs.Empty);
				if (this.Facing != dir) FacingChanged.SafeInvoke(this, new FacingChangedArgs(this.Facing, dir));
				this.Facing = dir;

				switch (dir) {
					case Facing.Up:
						if (speed == MovementSpeed.Walking)
							Animator.Play("walking-up");
						else if (speed == MovementSpeed.Running)
							Animator.Play("running-up");
						break;
					case Facing.Down:
						if (speed == MovementSpeed.Walking)
							Animator.Play("walking-down");
						else if (speed == MovementSpeed.Running)
							Animator.Play("running-down");
						break;
					case Facing.Left:
						if (speed == MovementSpeed.Walking)
							Animator.Play("walking-left");
						else if (speed == MovementSpeed.Running)
							Animator.Play("running-left");
						break;
					case Facing.Right:
						if (speed == MovementSpeed.Walking)
							Animator.Play("walking-right");
						else if (speed == MovementSpeed.Running)
							Animator.Play("running-right");
						break;
				}

				this.movement = -(dir.ToVector2() * new Vector2(16, 16));
				this.MovementSpeed = speed;
				this.MovementState = MovementState.Walking;
				this.Position -= this.movement;
			}
		}

		public void Face(Facing dir) {
			if (!Locked) {
				Initialize();
				if (this.Facing != dir) FacingChanged.SafeInvoke(this, new FacingChangedArgs(this.Facing, dir));
				this.Facing = dir;
				switch (this.Facing) {
					case Facing.Up:
						this.Animator.Play("face-up");
						break;
					case Facing.Down:
						this.Animator.Play("face-down");
						break;
					case Facing.Left:
						this.Animator.Play("face-left");
						break;
					case Facing.Right:
						this.Animator.Play("face-right");
						break;
				}
			}
		}

		public void TurnAround(Facing facing, bool templock) {
			Action callback = null;
			this.Turning = true;
			if (this.Facing != facing) FacingChanged.SafeInvoke(this, new FacingChangedArgs(this.Facing, facing));
			this.Facing = facing;

			if (templock) {
				Lock();
				callback = new Action(delegate() {
					this.Release(false);
					this.Turning = false;
				});
			}

			switch (facing) {
				case Facing.Up:
					this.Animator.Play("facechange-up", true, callback);
					break;
				case Facing.Down:
					this.Animator.Play("facechange-down", true, callback);
					break;
				case Facing.Left:
					this.Animator.Play("facechange-left", true, callback);
					break;
				case Facing.Right:
					this.Animator.Play("facechange-right", true, callback);
					break;
			}
		}

		public void Lock(float duration) {
			Lock("", duration);
		}

		public void Lock() {
			Lock("");
		}

		public void Lock(string uid, float duration) {
			Effects.Add(new LockEffect(uid, duration));
		}

		public void Lock(string uid) {
			if (!(Effects.OfType<LockEffect>().Any())) Locking.SafeInvoke(null, EventArgs.Empty);
			Effects.Add(new LockEffect(uid, Int32.MaxValue));
		}

		public void Release() {
			Release(false);
		}

		public void Release(bool force) {
			//Release all lock effects
			foreach (LockEffect effect in Effects.OfType<LockEffect>()) {
				if (!force && !String.IsNullOrEmpty(effect.Uid)) continue;
				effect.Alive = false;
			}
			Released.SafeInvoke(null, EventArgs.Empty);
		}

		public void Release(string uid) {
			foreach (LockEffect effect in Effects.OfType<LockEffect>().Where(effect => effect.Uid == uid)) {
				effect.Alive = false;
			}
			if (!(Effects.OfType<LockEffect>().Any())) Released.SafeInvoke(null, EventArgs.Empty);
		}

		public bool CanMove(Facing dir) {
			return this.CanMove(dir, 1);
		}

		public bool CanMove(Facing dir, int amount) {
			int tileX = (int) this.Position.X / 16;
			int tileY = (int) this.Position.Y / 16;

			Vector2 directionalVector = dir.ToVector2();
			tileX += (int) directionalVector.X * amount;
			tileY += (int) directionalVector.Y * amount;

			//GameConsole.WriteLine("CanMove at xt: {0}, yt: {0}", tileX, tileY);

			return this.CanMove(tileX, tileY);
		}

		public bool CanMove(int x, int y) {
			return Map.Walkable(x, y, this);
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);

			stream.Write((byte) this.Facing);
			stream.Write(Effects.Count);
			EffectIO io = new EffectIO(stream);
			Effects.ForEach(io.Write);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);

			this.Facing = (Facing) stream.ReadByte();
			EffectIO io = new EffectIO(stream);
			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				Effects.Add(io.Read());
			}

			return this;
		}
	}

	public class FacingChangedArgs : EventArgs {
		public Facing OldFacing;
		public Facing NewFacing;

		public FacingChangedArgs(Facing old, Facing New) {
			this.OldFacing = old;
			this.NewFacing = New;
		}
	}

	public class RequestingMoveArgs : EventArgs {
		public Facing Direction;
		public MovementSpeed Speed;

		public RequestingMoveArgs(Facing direction, MovementSpeed speed) {
			this.Direction = direction;
			this.Speed = speed;
		}
	}
}