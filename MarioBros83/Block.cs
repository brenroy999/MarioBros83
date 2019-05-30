using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros83
{
	class Block
	{
		public int x, y, size, scale;
		bool collide, punch;

		public Block(int _x, int _y, int _size, int _scale)
		{
			x = _x;
			y = _y;
			size = _size;
			scale = _scale;
		}

		private void Punched()
		{

		}
	}
}
