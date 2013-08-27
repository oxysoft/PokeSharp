using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Entities.Living.Core;
using GameEngine.Data.Entities.Living.Npcs;
using GameEngine.Data.Entities.Types;
using GameEngine.Data.Input;
using GameEngine.Data.Scripting.UserInterface;
using General.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Data.Entities.Living {
	public class LivingController {
		public LivingController(LivingEntity entity) {
			//Setup entity
			this.Entity = entity;
			this.Entity.Controller = this;
			this.Entity.Moving += OnMoving;
			this.Entity.FacingChanged += OnFacingChanged;

			//Setup default settings
			this.Queue = new Queue<Movement>();
			this.KeyboardInputEnabled = true;

			int xs = -((int) Entity.AbsolutePosition.X - (GameEngine.WIDTH >> 1));
			int ys = -((int) Entity.AbsolutePosition.Y - (GameEngine.HEIGHT >> 1));
		
			Entity.World.Camera.Location = new Vector2(xs, ys);
		}

		public LivingEntity Entity { get; private set; }
		public Vector2 CurrentPosition { get; private set; }
		protected Queue<Movement> Queue { get; private set; }
		public bool CacheMovements { get; set; }
		public bool KeyboardInputEnabled { get; set; }
		public bool CameraEnabled { get; set; }

		public void OnMoving(object sender, EventArgs eventArgs) {
			int xs = -((int) Entity.AbsolutePosition.X - GameEngine.WIDTH / 2);
			int ys = -((int) Entity.AbsolutePosition.Y - GameEngine.HEIGHT / 2);

			Entity.World.Camera.Location = new Vector2(xs, ys);
		}

		public void OnFacingChanged(object sender, FacingChangedArgs e) {
			lastFacing = e.OldFacing;
		}

		public virtual void CacheMovement(Facing direction, MovementSpeed speed) {
			if (this.CacheMovements) {
				this.Queue.Enqueue(new Movement(direction, speed));
			} else {
				this.Entity.TryMove(direction, speed);
			}
		}

		private float[] elapsed = new float[4]; //gameTime elapsed since key pressed down
		private Facing lastFacing;
		private bool npcSpawn = false;

		public void Update(GameTime time) {
			if (KeyboardInputEnabled && Queue.Count == 0) {
				KeyboardState state = InputHandler.Instance.State;
				KeyboardState lastState = InputHandler.Instance.LastState;

				if (state.IsKeyDown(Keys.N) && !npcSpawn && Entity.Position.X % 1 == 0 && Entity.Position.Y % 1 == 0) {
					List<EntityTemplate> list = Entity.World.EntityContainer.GetNpcs();
					NPCEntity npc = list[0].CreateEntity(Entity.World.EntityFactory, true) as NPCEntity;
					npc.Facing = Entity.Facing;
					npc.Map = Entity.Map;
					npc.Position = Entity.Position;
					npc.MovementBehavior = new MovementBehavior(npc);
					npc.MovementBehavior.Pattern = MovementPattern.LogicalRandom;
					npc.MovementBehavior.Frequency = MovementFrequency.Normally;
					npc.MovementBehavior.Speed = MovementSpeed.Walking;
					Entity.Map.Entities.Add(npc);
					npcSpawn = true;
				}

				if (!state.IsKeyDown(Keys.N)) npcSpawn = false;

				if (state.IsKeyDown(Keys.Enter) && Entity is PlayerEntity) {
					UI ui = Entity.World.UIContainer.Get("StartMenu").CreateUI(Entity.World.ViewData.SpriteBatch, Entity as PlayerEntity);
					Entity.World.GameScene.UIManager.Add(ui);
				}

				MovementSpeed speed = MovementSpeed.Walking;
				if (state.IsKeyDown(Options.B)) speed = MovementSpeed.Running;

				if (state.IsKeyDown(Keys.Left))
					elapsed[0] += (float) time.ElapsedGameTime.TotalSeconds;
				else elapsed[0] = 0;
				if (state.IsKeyDown(Keys.Right))
					elapsed[1] += (float) time.ElapsedGameTime.TotalSeconds;
				else elapsed[1] = 0;
				if (state.IsKeyDown(Keys.Up))
					elapsed[2] += (float) time.ElapsedGameTime.TotalSeconds;
				else elapsed[2] = 0;
				if (state.IsKeyDown(Keys.Down))
					elapsed[3] += (float) time.ElapsedGameTime.TotalSeconds;
				else elapsed[3] = 0;

				const float turnTime = 0.1f;

				if (Entity.Movable) {
					if (!state.IsKeyDown(Keys.Left) && lastState.IsKeyDown(Keys.Left) && elapsed[0] < turnTime && Entity.Facing != Facing.Left)
						Entity.TurnAround(Facing.Left, true);
					else if (!state.IsKeyDown(Keys.Right) && lastState.IsKeyDown(Keys.Right) && elapsed[1] < turnTime && Entity.Facing != Facing.Right)
						Entity.TurnAround(Facing.Right,  true);
					else if (!state.IsKeyDown(Keys.Up) && lastState.IsKeyDown(Keys.Up) && elapsed[2] < turnTime && Entity.Facing != Facing.Up)
						Entity.TurnAround(Facing.Up,  true);
					else if (!state.IsKeyDown(Keys.Down) && lastState.IsKeyDown(Keys.Down) && elapsed[3] < turnTime && Entity.Facing != Facing.Down)
						Entity.TurnAround(Facing.Down,  true);
				}

				if (state.IsKeyDown(Keys.Left) && (Entity.Facing == Facing.Left || (elapsed[0] >= turnTime)))
					this.CacheMovement(Facing.Left, speed);
				else if (state.IsKeyDown(Keys.Right) && (Entity.Facing == Facing.Right || (elapsed[1] > turnTime)))
					this.CacheMovement(Facing.Right, speed);
				else if (state.IsKeyDown(Keys.Up) && (Entity.Facing == Facing.Up || (elapsed[2] > turnTime)))
					this.CacheMovement(Facing.Up, speed);
				else if (state.IsKeyDown(Keys.Down) && (Entity.Facing == Facing.Down || (elapsed[3] > turnTime)))
					this.CacheMovement(Facing.Down, speed);
			}

			if (this.Queue.Count > 0 && this.Entity.Movable) {
				Movement movement = this.Queue.Dequeue();

				this.Entity.TryMove(movement.Facing, movement.Speed);
			}
			//GameConsole.WriteLine("Elapsed: " + elapsed);
		}
	}
}