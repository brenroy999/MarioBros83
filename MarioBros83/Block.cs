using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros83
{
	class Block
	{
		public int x, y, size, scale;
		public bool raised = false;

		public Block(int _x, int _y, int _size, int _scale)
		{
			x = _x;
			y = _y;
			size = _size;
			scale = _scale;
		}

		public bool Punched(Player p)
		{
			Rectangle rect1 = new Rectangle(p.x, p.y, p.width, p.height);
			Rectangle rect2 = new Rectangle(x, y, size, size);

			if (rect1.IntersectsWith(rect2) && rect1.Y < rect2.Y)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public bool Collision(Player p)
		{
			Rectangle rect1 = new Rectangle(p.x, p.y, p.width, p.height);
			Rectangle rect2 = new Rectangle(x, y, size, size);

			if (rect1.IntersectsWith(rect2))
			{
				 return true;
			}

			else
			{
				return false;
			}
		}
	}
}
