using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarioBros83
{
	public partial class MarioBros : Form
	{
		//Window Border adds 16x, 39y
		Rectangle bottom, background; //= new Rectangle(-16, 208, 288, 16);
		Player mario, luigi;

		private int spriteScale = 1;

		List<Block> BlocksVisual = new List<Block>();
		List<Block> BlocksPhysical = new List<Block>();
		List<Player> Players = new List<Player>();

		public MarioBros()
		{
			InitializeComponent();
			LoadObjects();
		}

		private void LoadObjects()
		{
			mario = new Player(32 * spriteScale, 182 * spriteScale, spriteScale, 16 * spriteScale, 24 * spriteScale, null);
			luigi = new Player(208, 182, 1, 16, 24, null);
			Players.Add(mario);
			Players.Add(luigi);

			#region Block Rows
			//First Row Left Side
			for (int i = 0; i < 17; i++)
			{
				Block b = new Block(-24 + i * 8, 64, 8, 8);
				BlocksVisual.Add(b);
				BlocksPhysical.Add(b);
			}

			//First Row Right Side
			for (int i = 0; i < 17; i++)
			{
				Block b = new Block(144 + i * 8, 64, 8, 8);
				BlocksVisual.Add(b);
				BlocksPhysical.Add(b);
			}

			//Second Row Center
			for (int i = 0; i < 14; i++)
			{
				Block b = new Block(72 + i * 8, 112, 8, 8);
				BlocksVisual.Add(b);
				BlocksPhysical.Add(b);
			}

			//Third Row Left Side
			for (int i = 0; i < 4; i++)
			{
				Block b = new Block(0 + i * 8, 120, 8, 8);
				BlocksVisual.Add(b);
				BlocksPhysical.Add(b);
			}

			//Third Row Right Side
			for (int i = 0; i < 4; i++)
			{
				Block b = new Block(224 + i * 8, 120, 8, 8);
				BlocksVisual.Add(b);
				BlocksPhysical.Add(b);
			}

			//Fourth Row Left Side
			for (int i = 0; i < 11; i++)
			{
				Block b = new Block(0 + i * 8, 160, 8, 8);
				BlocksVisual.Add(b);
				BlocksPhysical.Add(b);
			}

			//Fourth Row Right Side
			for (int i = 0; i < 11; i++)
			{
				Block b = new Block(168 + i * 8, 160, 8, 8);
				BlocksVisual.Add(b);
				BlocksPhysical.Add(b);
			}

			#endregion
		}

		private void Scaling()
		{
			//Player Values
			mario.x *= spriteScale;
			mario.y *= spriteScale;
			mario.width *= spriteScale;
			mario.height *= spriteScale;

		}

		private void ResetScaling()
		{
			spriteScale = 1;
			mario.x /= 3;
			mario.y /= 3;
			mario.width /= 3;
			mario.height /= 3;
		}

		private void MarioMove()
		{
			foreach (Player p in Players)
			{
				if (p.left) { p.x -= 2 * spriteScale; }

				else if (p.right) { p.x += 2 * spriteScale; }

				if (p.y > 182)
				{
					p.y = 182;
				}


				if (p.x > ((256 + 16) * spriteScale))
				{
					p.x = (-16 * spriteScale);
				}
				else if (p.x < ((-16) * spriteScale))
				{
					p.x = (256 + 16) * spriteScale;
				}
			}
		}

		private void MarioBros_KeyDown(object sender, KeyEventArgs e)
		{

			switch (e.KeyCode)
			{
				//Mario Controls
				case Keys.A:
					mario.left = true;
					mario.direction = "left";
					break;
				case Keys.D:
					mario.right = true;
					mario.direction = "right";
					break;
				case Keys.Space:
					if (mario.jump == false)
					{
						mario.direction = "up";
						mario.jump = true;
					}
					break;

				//Luigi Controls
				case Keys.Left:
					luigi.left = true;
					break;
				case Keys.Right:
					luigi.right = true;
					break;
				case Keys.NumPad0:
					luigi.jump = true;
					break;

				//Scaling
				case Keys.Z:
					if (spriteScale < 3)
					{
						spriteScale += 1;
					}
					else
					{
						ResetScaling();
					}
					Scaling();
					break;
			}

		}

		private void MarioBros_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.A:
					mario.left = false;
					break;
				case Keys.D:
					mario.right = false;
					break;
				case Keys.Space:
					mario.jump = false;
					break;

				//Luigi Controls
				case Keys.Left:
					luigi.left = false;
					break;
				case Keys.Right:
					luigi.right = false;
					break;
			}
		}

		private void marioJumping()
		{
			foreach (Player p in Players)
			{
				if (p.jumpTime < 12)
				{
					p.y -= 5;
					p.jumpTime++;
				}

				else if (p.jumpTime == 12 && p.y < 182)
				{
					p.y += 2;
				}
			}
		}

		private void gameTimer_Tick(object sender, EventArgs e)
		{
			#region Scaling
			//Window size with scaling
			this.Width = 256 * spriteScale;
			this.Height = 224 * spriteScale;

			//Static Elements
			background = new Rectangle(0, 0, 256 * spriteScale, 224 * spriteScale);
			bottom = new Rectangle(-16 * spriteScale, 208 * spriteScale, 288 * spriteScale, 16 * spriteScale);
			#endregion

			foreach (Player p in Players)
			{
				if (p.jump == true)
				{

					marioJumping();

				}

				if (p.jump == false && p.y < 182)
				{
					p.direction = "down";
					p.jump = false;
					p.y += 2;
				}

				if (p.jump == false && p.y == 182)
				{
					p.jumpTime = 0;
				}
			}

			MarioMove();


			//foreach (Block b in BlocksVisual)
			//{
			//	if (b.Punched(mario))
			//	{
			//		int i = 0;
			//		if (i < 4 && !b.raised)
			//		{
			//			b.y -= 2;
			//			i++;
			//		}
			//		else
			//		{
			//			b.raised = true;
			//		}
			//	}
			//}

			foreach (Block b in BlocksPhysical)
			{
				foreach (Player p in Players)
				{
					if (b.Collision(p))
					{
						if ((p.y + 14) < b.y)
						{
							p.isGrounded = true;
						}

						switch (p.direction)
						{
							case "left":
								p.x += 4;
								break;

							case "right":
								p.x -= 4;
								break;

							case "up":
								p.y += 4;
								break;

							case "down":
								p.y -= 2;
								break;
						}
						if (p.y == 182 || b.Collision(p))
						{
							p.jumpTime = 0;
							p.isGrounded = true;
						}
					}
					else if (!b.Collision(p))
					{
						p.isGrounded = false;
					}
				}
			}

			labelDebug.Text = "Scale: " + spriteScale +
					"\nMario X: " + mario.x +
					"\nMario Y: " + mario.y +
					"\nDirection: " + mario.direction +
					"\nisGrounded: " + mario.isGrounded;

			Refresh();
		}

		private void MarioBros_Paint(object sender, PaintEventArgs e)
		{
			Pen drawColliders = new Pen(Color.Blue);
			Pen drawVisual = new Pen(Color.Purple);
			Pen drawmario = new Pen(Color.Red);
			Pen drawluigi = new Pen(Color.GreenYellow);

			#region Pipe Graphics
			SolidBrush pipeOlive = new SolidBrush(Color.FromArgb(255, 112, 113, 12));
			e.Graphics.FillRectangle(pipeOlive, 245, 192, 11, 14);
			e.Graphics.FillRectangle(pipeOlive, 240, 201, 4, 6);

			SolidBrush pipebase = new SolidBrush(Color.FromArgb(255, 156, 182, 18));
			e.Graphics.FillRectangle(pipebase, 240, 191, 4, 10);
			e.Graphics.FillRectangle(pipebase, 244, 192, 1, 14);
			e.Graphics.FillRectangle(pipebase, 246, 192, 10, 8);

			SolidBrush pipedark = new SolidBrush(Color.FromArgb(255, 3, 36, 3));
			e.Graphics.FillRectangle(pipedark, 244, 192, 1, 14);
			e.Graphics.FillRectangle(pipedark, 240, 202, 5, 1);
			e.Graphics.FillRectangle(pipedark, 244, 201, 12, 1);

			SolidBrush pipeSemidark = new SolidBrush(Color.FromArgb(255, 43, 75, 8));
			e.Graphics.FillRectangle(pipeSemidark, 240, 203, 4, 2);
			e.Graphics.FillRectangle(pipeSemidark, 245, 202, 11, 2);

			SolidBrush pipeWhite = new SolidBrush(Color.White);
			e.Graphics.FillRectangle(pipeWhite, 245, 194, 11, 2);
			e.Graphics.FillRectangle(pipeWhite, 240, 193, 4, 2);

			#endregion

			//			e.Graphics.DrawImage(Properties.Resources.basic_map, background);
			e.Graphics.DrawRectangle(drawColliders, bottom);
			e.Graphics.DrawRectangle(drawmario, mario.x, mario.y, mario.width, mario.height);
			e.Graphics.DrawRectangle(drawluigi, luigi.x, luigi.y, luigi.width, luigi.height);

			for (int i = 0; i < BlocksVisual.Count; i++)
			{
				e.Graphics.DrawRectangle(drawVisual, BlocksVisual[i].x, BlocksVisual[i].y, BlocksVisual[i].size, BlocksVisual[i].size);
				//e.Graphics.DrawImage(Properties.Resources.Block, BlocksVisual[i].x, BlocksVisual[i].y, BlocksVisual[i].size, BlocksVisual[i].size);
			}

			for (int i = 0; i < BlocksPhysical.Count; i++)
			{
				e.Graphics.DrawRectangle(drawColliders, BlocksPhysical[i].x, BlocksPhysical[i].y, BlocksPhysical[i].size, BlocksPhysical[i].size);
				//e.Graphics.DrawImage(Properties.Resources.Block, BlocksVisual[i].x, BlocksVisual[i].y, BlocksVisual[i].size, BlocksVisual[i].size);
			}
		}
	}
}
