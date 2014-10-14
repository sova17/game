using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace game_scripts {

//	public class TMapController {
//		private TMap _map;
//		public TMapController(TMap map) {
//			this._map = map;
//		}
//		public void CalculateAvailableArea() {

//		}
//	}
//	public class TMap {
//		public TCell[,] Cells;
//		public TMap(int width, int height) {
//			Cells = new TCell[height, width];
//		}
//		public TCell this[int x, int y] { get { return Cells[x, y]; } set { Cells[x, y] = value; } }
//	}
//}

namespace game_scripts {
	abstract class TBaseShipController {
		private Queue<TBaseShip> _ships;
		public TBaseShip CurrentShip;
		public TBaseAction Wait;
		public TBaseAction Defense;
		public TBaseAction Rotate;
		public TBaseAction Damage;
		public TBaseAction Go;
		public abstract void AddShip(TBaseShip ship);
		public abstract void SubShip(TBaseShip ship);
	}
}
