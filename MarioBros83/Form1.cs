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

		private bool marioLeft = false, marioRight = false, marioJump = false,
					 luigiLeft = false, luigiRight = false, luigiJump = false;

		private int marioJumpTime, luigiJumpTime;
		private int spriteScale = 1;

		List<Block> BlockList;

		public MarioBros()
		{
			InitializeComponent();
			LoadPlayers();
		}

		private void LoadPlayers()
		{
			mario = new Player(32 * spriteScale, 182 * spriteScale, spriteScale, 16 * spriteScale, 24 * spriteScale, null);
			luigi = new Player(208, 182, 1, 16, 24, null);
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

		private void playerStuff()
		{
			if (marioLeft) {mario.x -= 2 * spriteScale;}

			else if (marioRight) {mario.x += 2 * spriteScale;}


			if (mario.x > ((256 + 16) * spriteScale))
			{
				mario.x = (-16 * spriteScale);
			}
			else if (mario.x < ((-16) * spriteScale))
			{
				mario.x = (256 + 16) * spriteScale;
			}
		}

		private void MarioBros_KeyDown(object sender, KeyEventArgs e)
		{

			switch (e.KeyCode)
			{
				//Mario Controls
				case Keys.A:
					marioLeft = true;
					break;
				case Keys.D:
					marioRight = true;
					break;
				case Keys.Space:
					marioJump = true;
					break;

				//Luigi Controls
				case Keys.Left:
					luigiLeft = true;
					break;
				case Keys.Right:
					luigiRight = true;
					break;
				case Keys.NumPad0:
					luigiJump = true;
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
					marioLeft = false;
					break;
				case Keys.D:
					marioRight = false;
					break;
				case Keys.Space:
					marioJump = false;
					break;

				//Luigi Controls
				case Keys.Left:
					luigiLeft = false;
					break;
				case Keys.Right:
					luigiRight = false;
					break;
			}
		}

		private void marioJumping()
		{

			if (marioJumpTime < 12)
			{
				mario.y -= 5;
				marioJumpTime++;
			}

			else if (marioJumpTime == 12 && mario.y < 182)
			{
				mario.y += 2;
			}

			else if (mario.y == 182)
			{
				marioJumpTime = 0;
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

			if (marioJump == true)
			{

				marioJumping();

			}

			if (marioJump == false && mario.y < 182)
			{
				mario.y += 2;
			}

			if (marioJump == false && mario.y == 182)
			{
				marioJumpTime = 0;
			}

			playerStuff();

			labelDebug.Text = "Scale: " + spriteScale +
					"\nMario X: " + mario.x +
					"\nMario Y" + mario.y;

			Refresh();
		}

		private void MarioBros_Paint(object sender, PaintEventArgs e)
		{
			Pen drawColliders = new Pen(Color.Blue);
			Pen drawmario = new Pen(Color.Red);
			Pen drawluigi = new Pen(Color.GreenYellow);

			e.Graphics.DrawImage(Properties.Resources.basic_map, background);
			e.Graphics.DrawRectangle(drawColliders, bottom);
			e.Graphics.DrawRectangle(drawmario, mario.x, mario.y, mario.width, mario.height);
			e.Graphics.DrawRectangle(drawluigi, luigi.x, luigi.y, luigi.width, luigi.height);

			for(int i = 0; i<BlockList.Count; i++)
			{
				e.Graphics.DrawRectangle(drawColliders, BlockList[i].x, BlockList[i].y, BlockList[i].size, BlockList[i].size);
			}
		}
	}
}
