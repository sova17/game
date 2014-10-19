using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseCell {
		public Int32 X { get; set; }
		public Int32 Y { get; set; }
		public Int32 Depth { get; set; }
		public TParameters BonusSpecificators { get; set; }
		public TWeather Weather { get; set; }
		// Here will be yet some parameters, for example about weather in the cell, etc
	}
	abstract class TMap {
		TBaseCell[,] Cells;
		public TMap(int width, int height) {
			this.Width = width;
			this.Height = height;
			this.Cells = new TBaseCell[width, height];
		}
		public int Width { get; protected set; }
		public int Height { get; protected set; }
		public TBaseCell this[int x, int y] {
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