using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using General.Graphics.Common;
using General.Utilities;
using MapEditor.UI.Core.Common.Maths;

namespace MapEditor.UI.Core.Common.Noise {
	public class PerlinNoise : INoise {
		public Bitmap NoiseMap { get; set; }
		public int Width, Height;
		private int[] permutations;
		private double[] noiseValues;
		public double XCoord;
		public double YCoord;
		public double ZCoord;

		public PerlinNoise(int width, int height) {
			this.Width = width;
			this.Height = height;
			Random par1Random = new Random();
			this.permutations = new int[512];
			this.XCoord = par1Random.NextDouble() * 256.0D;
			this.YCoord = par1Random.NextDouble() * 256.0D;
			this.ZCoord = par1Random.NextDouble() * 256.0D;
			int var2;

			for (var2 = 0; var2 < 256; this.permutations[var2] = var2++) {
			}

			for (var2 = 0; var2 < 256; ++var2) {
				int var3 = par1Random.Next(256 - var2) + var2;
				int var4 = this.permutations[var2];
				this.permutations[var2] = this.permutations[var3];
				this.permutations[var3] = var4;
				this.permutations[var2 + 256] = this.permutations[var2];
			}
		}

		public INoise Generate() {
			LockBitmap lockNoise = new LockBitmap(new Bitmap(Width, Height));
			lockNoise.Lock();

			noiseValues = new double[Width * Height];
			Generate(0, 0, 0, 5, 5, 5, 5, 5, 5, 2);

			for (int i = 0; i < lockNoise.Height; i++) {
				int x = i % this.Width;
				int y = i / this.Width;

				byte cval = (byte) (255f * noiseValues[i]);
				Color col = Color.FromArgb(cval, cval, cval);

				 lockNoise.SetPixel(x, y, col);
			}

			this.NoiseMap = lockNoise.Unlock();
			return this;
		}

		public void Generate(double xOffset, double yOffset, double zOffset, int xSize, int ySize, int zSize, double xScale, double yScale, double zScale, double noiseScale) {
			int var19;
			int var22;
			double var31;
			double var35;
			double var38;
			int var37;
			double var42;
			int var40;
			int var41;
			int var10001;
			int var77;

			if (ySize == 1) {
				bool var66 = false;
				bool var65 = false;
				bool var21 = false;
				bool var67 = false;
				double var72 = 0.0D;
				double var71 = 0.0D;
				var77 = 0;
				double var74 = 1.0D / noiseScale;

				for (int var30 = 0; var30 < xSize; ++var30) {
					var31 = xOffset + (double) var30 * xScale + this.XCoord;
					int var78 = (int) var31;

					if (var31 < (double) var78) {
						--var78;
					}

					int var34 = var78 & 255;
					var31 -= (double) var78;
					var35 = var31 * var31 * var31 * (var31 * (var31 * 6.0D - 15.0D) + 10.0D);

					for (var37 = 0; var37 < zSize; ++var37) {
						var38 = zOffset + (double) var37 * zScale + this.ZCoord;
						var40 = (int) var38;

						if (var38 < (double) var40) {
							--var40;
						}

						var41 = var40 & 255;
						var38 -= (double) var40;
						var42 = var38 * var38 * var38 * (var38 * (var38 * 6.0D - 15.0D) + 10.0D);
						var19 = this.permutations[var34] + 0;
						int var64 = this.permutations[var19] + var41;
						int var69 = this.permutations[var34 + 1] + 0;
						var22 = this.permutations[var69] + var41;
						var72 = this.lerp(var35, this.func_76309_a(this.permutations[var64], var31, var38), this.grad(this.permutations[var22], var31 - 1.0D, 0.0D, var38));
						var71 = this.lerp(var35, this.grad(this.permutations[var64 + 1], var31, 0.0D, var38 - 1.0D), this.grad(this.permutations[var22 + 1], var31 - 1.0D, 0.0D, var38 - 1.0D));
						double var79 = this.lerp(var42, var72, var71);
						var10001 = var77++;
						noiseValues[var10001] += var79 * var74;
					}
				}
			} else {
				var19 = 0;
				double var20 = 1.0D / noiseScale;
				var22 = -1;
				bool var23 = false;
				bool var24 = false;
				bool var25 = false;
				bool var26 = false;
				bool var27 = false;
				bool var28 = false;
				double var29 = 0.0D;
				var31 = 0.0D;
				double var33 = 0.0D;
				var35 = 0.0D;

				for (var37 = 0; var37 < xSize; ++var37) {
					var38 = xOffset + (double) var37 * xScale + this.XCoord;
					var40 = (int) var38;

					if (var38 < (double) var40) {
						--var40;
					}

					var41 = var40 & 255;
					var38 -= (double) var40;
					var42 = var38 * var38 * var38 * (var38 * (var38 * 6.0D - 15.0D) + 10.0D);

					for (int var44 = 0; var44 < zSize; ++var44) {
						double var45 = zOffset + (double) var44 * zScale + this.ZCoord;
						int var47 = (int) var45;

						if (var45 < (double) var47) {
							--var47;
						}

						int var48 = var47 & 255;
						var45 -= (double) var47;
						double var49 = var45 * var45 * var45 * (var45 * (var45 * 6.0D - 15.0D) + 10.0D);

						for (int var51 = 0; var51 < ySize; ++var51) {
							double var52 = yOffset + (double) var51 * yScale + this.YCoord;
							int var54 = (int) var52;

							if (var52 < (double) var54) {
								--var54;
							}

							int var55 = var54 & 255;
							var52 -= (double) var54;
							double var56 = var52 * var52 * var52 * (var52 * (var52 * 6.0D - 15.0D) + 10.0D);

							if (var51 == 0 || var55 != var22) {
								var22 = var55;
								int var68 = this.permutations[var41] + var55;
								int var73 = this.permutations[var68] + var48;
								int var70 = this.permutations[var68 + 1] + var48;
								int var76 = this.permutations[var41 + 1] + var55;
								var77 = this.permutations[var76] + var48;
								int var75 = this.permutations[var76 + 1] + var48;
								var29 = this.lerp(var42, this.grad(this.permutations[var73], var38, var52, var45), this.grad(this.permutations[var77], var38 - 1.0D, var52, var45));
								var31 = this.lerp(var42, this.grad(this.permutations[var70], var38, var52 - 1.0D, var45), this.grad(this.permutations[var75], var38 - 1.0D, var52 - 1.0D, var45));
								var33 = this.lerp(var42, this.grad(this.permutations[var73 + 1], var38, var52, var45 - 1.0D), this.grad(this.permutations[var77 + 1], var38 - 1.0D, var52, var45 - 1.0D));
								var35 = this.lerp(var42, this.grad(this.permutations[var70 + 1], var38, var52 - 1.0D, var45 - 1.0D), this.grad(this.permutations[var75 + 1], var38 - 1.0D, var52 - 1.0D, var45 - 1.0D));
							}

							double var58 = this.lerp(var56, var29, var31);
							double var60 = this.lerp(var56, var33, var35);
							double var62 = this.lerp(var49, var58, var60);
							var10001 = var19++;
							noiseValues[var10001] += var62 * var20;
						}
					}
				}
			}
		}

		public double lerp(double par1, double par3, double par5) {
			return par3 + par1 * (par5 - par3);
		}

		public double func_76309_a(int par1, double par2, double par4) {
			int var6 = par1 & 15;
			double var7 = (double) (1 - ((var6 & 8) >> 3)) * par2;
			double var9 = var6 < 4 ? 0.0D : (var6 != 12 && var6 != 14 ? par4 : par2);
			return ((var6 & 1) == 0 ? var7 : -var7) + ((var6 & 2) == 0 ? var9 : -var9);
		}

		public double grad(int par1, double par2, double par4, double par6) {
			int var8 = par1 & 15;
			double var9 = var8 < 8 ? par2 : par4;
			double var11 = var8 < 4 ? par4 : (var8 != 12 && var8 != 14 ? par6 : par2);
			return ((var8 & 1) == 0 ? var9 : -var9) + ((var8 & 2) == 0 ? var11 : -var11);
		}
	}
}