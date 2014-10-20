using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	class TCell {
		public Int32 X { get; set; }
		public Int32 Y { get; set; }
		public Int32 Depth { get; set; }
		public TParameters Bonus { get; set; }
		public TWeather Weather { get; set; }
	}
	abstract class TMap {
		TCell[,] Cells;
		public TMap(int width, int height) {
			this.Width = width;
			this.Height = height;
			this.Cells = new TCell[width, height];
		}
		public int Width { get; protected set; }
		public int Height { get; protected set; }
		public TCell this[int x, int y] {
			get {
				if (x >= 0 && x < Width && y >= 0 && y < Height)
					return Cells[x, y];
				else
					throw new IndexOutOfRangeException();
			}
			set {
				if (x >= 0 && x < Width && y >= 0 && y < Height)
					Cells[x, y] = value;
				else
					throw new IndexOutOfRangeException();
			}
		}
	}
}