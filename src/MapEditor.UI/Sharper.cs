using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using MapEditor.UI.Core.Common;
using MapEditor.UI.Core.Common.Brushes;
using MapEditor.UI.Core.Common.Noise;
using MapEditor.UI.Core.Extensions;
using MapEditor.UI.Core.Transitions;
using MapEditor.UI.FastColoredTextbox;
using Button = System.Windows.Forms.Button;

namespace MapEditor.UI {
	public class Sharper : ThemeBase {
		protected override void ColorHook() {
		}

		protected override void PaintHook() {
		}
	}

	//Controls

	[ToolboxBitmap(typeof (Button))]
	public sealed class SharperButton : Control {
		public bool Hover;
		public bool Clicked;
		public Image Image { get; set; }

		public SharperButton() {
			SetStyle((ControlStyles) 139286, true);
			SetStyle(ControlStyles.Selectable, false);
			this.Text = "Button";
		}

		protected override void OnMouseLeave(EventArgs e) {
			Hover = false;
			Invalidate();
			base.OnMouseLeave(e);
		}

		protected override void OnMouseEnter(EventArgs e) {
			Hover = true;
			Invalidate();
			base.OnMouseEnter(e);
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			Clicked = false;
			Invalidate();
			base.OnMouseUp(e);
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			Clicked = true;
			Invalidate();
			base.OnMouseDown(e);
		}

		private NoiseBrush b1;

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			GraphicsHelper helper = new GraphicsHelper(g);

			if (b1 == null) b1 = new NoiseBrush(new WhiteNoise(Width, Height).SetRange(210, 240).Generate(), 0.4f);

			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			g.Clear(BackColor);
			g.SmoothingMode = SmoothingMode.AntiAlias;

			Pen p1 = new Pen(Color.FromArgb(24, 24, 24));
			Pen p12 = new Pen(Color.FromArgb(135, 175, 235));
			Pen p2 = new Pen(Color.FromArgb(120, 120, 120));
			Pen p3 = new Pen(Color.FromArgb(123, 205, 254));
			Pen p4 = new Pen(Color.FromArgb(103, 164, 194));
			Pen p5 = new Pen(Color.FromArgb(60, 130, 170));
			Pen p6 = new Pen(Color.FromArgb(30, 70, 90));
			Pen p7 = new Pen(Color.FromArgb(190, 190, 190));

			GraphicsPath gp1 = helper.CreateRound(0, 0, Width - 1, Height - 2, 4);
			GraphicsPath gp2 = helper.CreateRound(1, 1, Width - 3, Height - 4, 4);

			LinearGradientBrush disabled = new LinearGradientBrush(ClientRectangle, Color.FromArgb(170, 170, 170), Color.FromArgb(140, 140, 140), 90f);
			LinearGradientBrush neither = new LinearGradientBrush(ClientRectangle, Color.FromArgb(120, 190, 250), Color.FromArgb(100, 160, 190), 90f);
			LinearGradientBrush hover = new LinearGradientBrush(ClientRectangle, Color.FromArgb(66, 190, 255), Color.FromArgb(37, 140, 190), 90f);
			LinearGradientBrush clicked = new LinearGradientBrush(ClientRectangle, Color.FromArgb(77, 159, 207), Color.FromArgb(21, 103, 151), 90f);

			if (Enabled) {
				if (Hover) {
					if (!Clicked) { //Hovering
						g.FillPath(hover, gp1);
						g.DrawPath(p1, gp1);
						g.DrawLine(p2, new Point(2, Height - 1), new Point(Width - 3, Height - 1));
						g.DrawLine(p5, new Point(2, Height - 3), new Point(Width - 3, Height - 3));
						g.DrawLine(p2, new Point(2, Height - 1), new Point(Width - 3, Height - 1));
						g.DrawPath(p3, gp2);
						g.FillPath(b1, gp1);
					} else { //Clicked
						g.FillPath(clicked, gp1);
						g.DrawPath(p1, gp1);
						g.DrawLine(p2, new Point(2, Height - 1), new Point(Width - 3, Height - 1));
						g.DrawLine(p6, new Point(2, Height - 3), new Point(Width - 3, Height - 3));
						g.DrawLine(p2, new Point(2, Height - 1), new Point(Width - 3, Height - 1));
						g.DrawPath(p4, gp2);
						g.FillPath(b1, gp1);
					}
				} else { //Neither
					g.FillPath(neither, gp1);
					g.DrawPath(p1, gp1);
					g.DrawPath(p12, gp2);
					g.DrawLine(p2, new Point(2, Height - 1), new Point(Width - 3, Height - 1));
					g.FillPath(b1, gp1);
				}
			} else {
				g.FillPath(disabled, gp1);
				g.DrawPath(p1, gp1);
				g.DrawPath(p7, gp2);
				g.DrawLine(p2, new Point(2, Height - 1), new Point(Width - 3, Height - 1));
				g.FillPath(b1, gp1);
			}
			Font font = this.Font;
			SizeF sz1 = g.MeasureString(this.Text, font);

			if (Clicked) {
				sz1.Height -= 2;
			}

			g.DrawString(this.Text, font, Brushes.Black, new PointF((int) (Width / 2f - sz1.Width / 2f) + 1, (int) (Height / 2f - sz1.Height / 2f) + 1));
			g.DrawString(this.Text, font, Brushes.White, new PointF((int) (Width / 2f - sz1.Width / 2f), (int) (Height / 2f - sz1.Height / 2f)));
		}
	}

	[ToolboxBitmap(typeof (CheckBox))]
	public class SharperCheckBox : CheckBox {
		public SharperCheckBox() {
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.Cursor = Cursors.Hand;
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			GraphicsHelper helper = new GraphicsHelper(g);

			g.Clear(Parent.BackColor);
			g.SmoothingMode = SmoothingMode.AntiAlias;

			Rectangle box = new Rectangle(0, 0, 15, 15);

			GraphicsPath gp1 = helper.CreateRoundedPath(box, 3);

			GraphicsPath pathCheck = new GraphicsPath();
			pathCheck.AddLine(0, 4, 1, 4);
			pathCheck.AddLine(1, 4, 4, 7);
			pathCheck.AddLine(4, 7, 11, 0);
			pathCheck.AddLine(11, 0, 12, 1);
			pathCheck.AddLine(12, 1, 4, 9);
			pathCheck.AddLine(4, 9, 0, 5);
			pathCheck.AddLine(0, 5, 0, 4);
			pathCheck.AddLine(0, 4, 4, 8);
			pathCheck.AddLine(4, 8, 11, 1);

			Pen p1 = new Pen(Color.FromArgb(209, 209, 209));
			Pen p2 = new Pen(Color.FromArgb(68, 110, 175));
			Pen p3 = new Pen(Color.FromArgb(88, 160, 215));
			Brush b1 = new SolidBrush(Color.FromArgb(233, 233, 233));

			g.FillPath(b1, gp1);
			g.DrawPath(p1, gp1);

			if (this.Checked) {
				g.DrawPath(p3, pathCheck, 2, 3);
			}

			g.DrawString(this.Text, this.Font, Brushes.Black, new PointF(box.X + box.Width + 3, box.Y + 2));
		}
	}

	[ToolboxBitmap(typeof (RadioButton))]
	public class SharperRadioBox : RadioButton {
		public SharperRadioBox() {
			this.Cursor = Cursors.Hand;
		}

		protected override void OnPaint(PaintEventArgs pevent) {
			Graphics g = pevent.Graphics;
			GraphicsHelper helper = new GraphicsHelper(g);

			g.Clear(Parent.BackColor);

			GraphicsPath gp1 = helper.CreateRound(0, 0, 15, 15, 16);
			GraphicsPath gp2 = helper.CreateRound(4, 4, 7, 7, 7);

			Pen p1 = new Pen(Color.FromArgb(209, 209, 209));
			Brush b1 = new SolidBrush(Color.FromArgb(88, 160, 215));
			Brush b2 = new SolidBrush(Color.FromArgb(233, 233, 233));

			g.FillPath(b2, gp1);
			g.DrawPath(p1, gp1);

			if (this.Checked) {
				g.FillPath(b1, gp2);
			}

			g.DrawString(this.Text, this.Font, Brushes.Black, new PointF(16 + 2, 2));
		}
	}

	[ToolboxBitmap(typeof (GroupBox))]
	public class SharperGroupBox : GroupBox {
		public SharperGroupBox() {
			this.BackColor = Color.FromArgb(233, 233, 233);
		}
	}

	[ToolboxBitmap(typeof (TextBox))]
	public sealed class SharperTextBox : FastColoredTextBox {
		public SharperTextBox() {
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.Selectable, true);
			this.DoubleBuffered = true;

			this.Multiline = false;
			this.SyntaxHighlighter = null;
			this.ShowLineNumbers = false;

			this.GlowIntensity = 0;

			this.TerminalGlowIntensity = 15;
			this.TerminalGlowFeather = 50;

			this.RenderOffsetX = TerminalGlowIntensity;
			this.RenderOffsetY = TerminalGlowIntensity - 2;
			this.MinimumSize = new Size(25, 24);

			this.Size = MinimumSize;
		}

		private PerlinNoise perlin;
		private int glowIntensity;
		private int glowFeather;

		[Browsable(true)]
		[DefaultValue(15)]
		[Description("The glow intensity when control has focused.")]
		public int TerminalGlowIntensity { get; set; }

		[Browsable(true)]
		[DefaultValue(50)]
		[Description("The glow feather when control has focused.")]
		public int TerminalGlowFeather { get; set; }

		[Browsable(false)]
		[DefaultValue(0)]
		public int GlowIntensity {
			get { return glowIntensity; }
			set {
				glowIntensity = value;
				Invalidate();
			}
		}

		[Browsable(false)]
		[DefaultValue(0)]
		public int GlowFeather {
			get { return glowFeather; }
			set {
				glowFeather = value;
				Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
		}

		protected override void OnPaintBackground(PaintEventArgs e) {
			Graphics g = e.Graphics;
			GraphicsHelper helper = new GraphicsHelper(g);

			g.Clear(this.BackColor);

			Rectangle bounds = new Rectangle((TerminalGlowIntensity + 1) / 2, (TerminalGlowIntensity + 1) / 2, Width - (TerminalGlowIntensity + 1), Height - (TerminalGlowIntensity + 1));
			GraphicsPath gp1 = helper.CreateRoundedPath(bounds, 3);

			if (perlin == null) perlin = new PerlinNoise(Width, Height).Generate() as PerlinNoise;

			Brush b1 = new LinearGradientBrush(bounds, Color.FromArgb(197, 197, 197), Color.FromArgb(205, 205, 205), 90);
			Brush b2 = new SolidBrush(Color.FromArgb(251, 251, 251));
			Brush b3 = new HatchBrush(HatchStyle.OutlinedDiamond, Color.FromArgb(10, Color.Black), Color.Transparent);
			Pen p = new Pen(b1);

			g.DrawGlow(gp1, Color.SkyBlue, GlowIntensity, GlowFeather);

			g.FillPath(b2, gp1);
			g.DrawPath(p, gp1);
			g.FillPath(perlin.NoiseMap, 1f, gp1);
			g.FillPath(b3, gp1);
			g.DrawImage(perlin.NoiseMap, new Rectangle(0, 0, perlin.NoiseMap.Width, perlin.NoiseMap.Height));
		}

		private static int transitionTime = 250;
		private ITransitionType transition = new TransitionType_Deceleration(150);

		protected override void OnGotFocus(EventArgs e) {
			Transition t = new Transition(transition);
			t.Add(this, "GlowIntensity", TerminalGlowIntensity);
			t.Add(this, "GlowFeather", TerminalGlowFeather);
			t.Run();
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e) {
			Transition t = new Transition(transition);
			t.Add(this, "GlowIntensity", 0);
			t.Add(this, "GlowFeather", 0);
			t.Run();
			base.OnGotFocus(e);
		}

		protected override void OnPaintLine(PaintLineEventArgs e) {
			base.OnPaintLine(e);
		}

		protected override void OnClick(EventArgs e) {
			this.Focus();
			this.Invalidate();
			base.OnClick(e);
		}
	}
}