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

namespace templates {
	class TBaseMap {
	}
	abstract class TBaseMapController {
		public abstract void CalculateAvailableArea(TBaseMap map);
	}
	abstract class TBaseWeatherController {
		//private abstract void GenerateFirstWeather(TBaseMap map);
		public abstract void GenerateWeather(TBaseMap map);
	}
	abstract class TBaseDamageController {
		public abstract int CalculateDamage(TBaseShip damager, TBaseShip defenser, TDirection direction);
	}
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
	abstract class TBaseAction {
		public abstract void Execute(TBaseShipController shipController, Object obj);
	}
	abstract class TBaseShipAction : TBaseAction {
		public void Execute(TBaseShipController shipController, Object obj) {
			Execute(shipController, (TBaseShip)obj);
		}
		public abstract void Execute(TBaseShipController shipController, TBaseShip ship);
	}
	abstract class TBaseCellAction :TBaseAction {
		public void Execute(TBaseShipController shipController, Object obj) {
			Execute(shipController, (TBaseCell)obj);
		}
		public abstract void Execute(TBaseShipController shipController, TBaseCell cell);
	}
	class TBaseCell {

	}
	class TBaseShip {

	}
	/// <summary>
	/// for initializing TShipController and abstraction between inside and outside representation
	/// </summary>
	class TBattleController {

	}
	enum TDirection {
		Left,
		Right,
		Tail,
		Head
	}
}
