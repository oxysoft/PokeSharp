using System;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Entities.Core;
using General.Common;
using General.Extensions;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions;
using MapEditor.Data.Actions.Object;
using MapEditor.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.States.EntityEditor {
	public class EntityRectangleTool : State, IState {
		public string Name {
			get { return "Entity Fill"; }
		}

		public Selection selection;

		public EntityRectangleTool() {
			this.selection = new Selection();
		}

		public static EntityRectangleTool Instance {
			get { return Static<EntityRectangleTool>.Value; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			EditorForm.b_entityrectangle.Checked = true;

			EditorForm.editorcontrol.MouseDown += OnMouseDown;
			EditorForm.editorcontrol.MouseMove += OnMouseMove;
			EditorForm.editorcontrol.MouseUp += OnMouseUp;
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			EditorForm.b_entityrectangle.Checked = false;

			EditorForm.editorcontrol.MouseDown -= OnMouseDown;
			EditorForm.editorcontrol.MouseMove -= OnMouseMove;
			EditorForm.editorcontrol.MouseUp -= OnMouseUp;
		}

		public void OnMouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale);

				selection.Start(new Vector2(xt, yt));
			}
		}

		public void OnMouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale);

				selection.End(new Vector2(xt, yt));
			}
		}

		public void OnMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int xs = selection.Region.X;
				int ys = selection.Region.Y;
				int width = selection.Region.Width;
				int height = selection.Region.Height;

				EntityTemplate template = FrmEntitySelector.Instance.selectedEntity;

				int tx = Int32.MaxValue;
				int ty = Int32.MaxValue;
				int tw = -1;
				int th = -1;

				foreach (Rectangle rect in template.CollisionMap) {
					if (rect.X < tx) tx = rect.X;
					if (rect.Y < ty) ty = rect.Y;
					if (rect.Width > tw) tw = rect.Width;
					if (rect.Height > th) th = rect.Height;
				}

				if (tw != template.Texture.Texture.Width) tw += 1;
				//if (th != Template.Texture.Texture.Height) th += 1;

				Rectangle tbounds = new Rectangle(tx, ty, tw, th);

				int xCount = (int) Math.Ceiling(((double) width / tbounds.Width));
				int yCount = (int) Math.Ceiling(((double) height / tbounds.Height));

				MultiAction action = new MultiAction(Name);

				int xInc = 0;
				int yInc = 0;

				//if (tw != Template.Texture.Texture.Width) xInc -= 1;
				if (th != template.Texture.Texture.Height) yInc -= 1;

				for (int j = 0; j < yCount; j++, yInc += tbounds.Height, xInc = 0) {
					for (int i = 0; i < xCount; i++, xInc += tbounds.Width) {
						action.Actions.Add(new AddEntityAction(template, new Vector2(xs + xInc, ys + yInc)));
					}
				}

				EditorEngine.Instance.GetActionManager().Execute(action);
			}

			selection.Region = Rectangle.Empty;
		}

		public void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			SpriteBatch spriteBatch = EditorEngine.Instance.World.ViewData.SpriteBatch;

			if (selection.Region != Rectangle.Empty) {
				int xs = (int) EditorEngine.Instance.World.Camera.Location.X;
				int ys = (int) EditorEngine.Instance.World.Camera.Location.Y;

				float scale = EditorEngine.Instance.World.Camera.Scale;
				Vector2 scroll = EditorEngine.Instance.World.Camera.Location;

				Rectangle target = new Rectangle((int) (selection.Region.X * scale * 16 + scroll.X), (int) (selection.Region.Y * scale * 16 + scroll.Y), (int) (selection.Region.Width * 16 * scale), (int) (selection.Region.Height * 16 * scale));

				SelectionUtil.DrawRectangle(spriteBatch, Color.Black, target.Add(new Vector2(1, 1)));
				SelectionUtil.DrawRectangle(spriteBatch, Color.White, target);
			}
		}

		public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
		}
	}
}