using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Graphics.Common;
using MapEditor.UI.Core.Common.Brushes;

namespace MapEditor.UI.Core.Extensions {
	public static class GraphicsExtensions {
		public static void FillPath(this Graphics g, Image img, GraphicsPath path) {
			FillPath(g, img, 1f, path);
		}

		public static void FillPath(this Graphics g, Image img, float opacity, GraphicsPath path) {
			g.SetClip(path);
			float[][] matrixItems = {
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, opacity, 0},
				new float[] {0, 0, 0, 0, 1}
			};
			ColorMatrix matrix = new ColorMatrix(matrixItems);

			ImageAttributes attributes = new ImageAttributes();
			attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

			g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0f, 0f, img.Width, img.Height, GraphicsUnit.Pixel, attributes);
			g.ResetClip();
		}

		public static void FillPath(this Graphics g, IBrush brush, GraphicsPath path) {
			brush.Fill(g, path);
		}

		public static void DrawPath(this Graphics g, Pen pen, GraphicsPath path, int x, int y) {
			GraphicsPath ret = new GraphicsPath();

			Point[] points = new Point[path.PointCount];

			for (int i = 0; i < path.PointCount; i++) {
				points[i] = new Point((int) path.PathPoints[i].X + x, (int) path.PathPoints[i].Y + y);
			}

			for (int i = 0; i < points.Length; i += 2) {
				ret.AddLine(points[i], points[i + 1]);
			}

			g.DrawPath(pen, ret);
		}

		public static void DrawGlow(this Graphics g, GraphicsPath gp, Color c, int glow, int feather) {
			if (glow > 0) {
				g.SetClip(gp, CombineMode.Exclude);
				for (int i = 0; i <= glow; i += 2) {
					Pen p = new Pen(Color.FromArgb((feather - ((feather / glow) * i)), c), i);
					p.LineJoin = LineJoin.Round;
					g.DrawPath(p, gp);
				}
				g.ResetClip();
			}
		}
	}
}