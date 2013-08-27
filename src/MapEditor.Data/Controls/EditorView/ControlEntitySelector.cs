using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GameEngine.Data.Entities;
using GameEngine.Data.Entities.Core;
using General.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlEntitySelector : GameControl {

		public ControlEntitySelector() {
			this.Dock = DockStyle.Fill;
		}

		public event EventHandler onTemplateSelected;
		private EntityTemplate selectedEntity;
		private ScrollBar scrollBar;
		private FluentScrolling scrolling;
		private int lastCount = 0;

		public EntityTemplate SelectedEntity {
			get {
				return selectedEntity;
			}
		}

		private EntityTemplate getEntity(int x, int y) {
			int index = 0;
			foreach (Rectangle bounds in getEntityBounds()) {
				if (bounds.Contains(x, y)) {
					return EditorEngine.Instance.World.EntityContainer.GetBuildings()[index];
				}
				index++;
			}
			return null;
		}

		private IEnumerable<Rectangle> getEntityBounds() {
			List<Rectangle> result = new List<Rectangle>();
			int cx = 0;
			int cy = 0;

			int maxHeight = int.MinValue;

			foreach (EntityTemplate tmp in EditorEngine.Instance.World.EntityContainer.GetBuildings()) {
				int w = tmp.Texture.FrameWidth;
				int h = tmp.Texture.FrameHeight;

				if (cx + w > Width) {
					cy += maxHeight;
					cx = 0;
					maxHeight = int.MinValue;
				}

				if (h > maxHeight) {
					maxHeight = h;
				}

				result.Add(new Rectangle(cx, cy, w, h));
				cx += w;
			}
			return result;
		}

		public void initialize(ScrollBar scrollBar) {
			this.scrollBar = scrollBar;
			this.scrolling = new FluentScrolling(scrollBar);
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			this.selectedEntity = this.getEntity(e.X, e.Y + this.scrolling.Value);

			if (selectedEntity != null) {
				onTemplateSelected.SafeInvoke(this, EventArgs.Empty);
			}

			base.OnMouseDown(e);
		}

		protected override void OnMouseWheel(MouseEventArgs e) {
			int delta = this.scrollBar.Value - e.Delta;

			delta = Math.Min((int) scrollBar.Maximum, delta);
			delta = Math.Max((int) scrollBar.Minimum, delta);

			this.scrollBar.Value = delta;

			base.OnMouseWheel(e);
		}

		public override void Update(GameTime time) {
			scrolling.Update(time);

			// Could be optimized to be on count updated instead
			if (lastCount < EditorEngine.Instance.World.EntityContainer.GetBuildings().Count()) {
				Rectangle lb = this.getEntityBounds().Last<Rectangle>();
				lastCount = getEntityBounds().Count<Rectangle>();
				this.scrollBar.Maximum = Math.Max(0, lb.Y + lb.Height - Height);
			}
			base.Update(time);
		}

		public override void Draw(GameTime time) {
			SpriteBatch batch = EditorEngine.Instance.World.ViewData.SpriteBatch;

			List<Rectangle> collisions = getEntityBounds().ToList();
			int index = 0;

			foreach (EntityTemplate tmp in EditorEngine.Instance.World.EntityContainer.GetBuildings()) {
				MapEntity e = tmp.CreateEntity(EditorEngine.Instance.World.EntityFactory, false);

				if (e != null) {
					e.Position = new Vector2(collisions[index].X, collisions[index].Y - scrolling.Value);

					e.BeginDraw(time);
					e.Draw(time);
					e.EndDraw(time);

					//cute stuff!
					if (tmp == selectedEntity) {
						MapEntity e2 = tmp.CreateEntity(EditorEngine.Instance.World.EntityFactory, false);

						e2.Position = new Vector2(collisions[index].X, collisions[index].Y - scrolling.Value);

						e2.Color = Color.White;
						e2.Opacity = 0.5f;
						e2.Shadow = false;
						e2.blendstate = BlendState.Additive;

						e2.BeginDraw(time);
						e2.Draw(time);
						e2.EndDraw(time);
					}
					index++;
				}
			}

			base.Draw(time);
		}

	}
}
