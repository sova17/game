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
	abstract class TBaseMap {
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
		public override void Execute(TBaseShipController shipController, Object obj) {
			Execute(shipController, (TBaseShip)obj);
		}
		public abstract void Execute(TBaseShipController shipController, TBaseShip ship);
	}
	abstract class TBaseCellAction : TBaseAction {
		public override void Execute(TBaseShipController shipController, Object obj) {
			Execute(shipController, (TBaseCell)obj);
		}
		public abstract void Execute(TBaseShipController shipController, TBaseCell cell);
	}
	abstract class TBaseCell {
		public int X { get; set; }
		public int Y { get; set; }
		public int Depth { get; set; }
		//public TSpecificators BonusSpecificators { get; set; }
	
	}
	abstract class TBaseShip {
		public String Name { get; set; }
		public String ClassName { get; set; }
		public int CreationYear { get; set; }
		public TNation CreationNation { get; set; }
		public TNation PlayingNation { get; set; }
		public int Level { get; set; }
		public int Experience { get; set; }
		public int RequiredCommandLevel { get; set; }
		public int Width { get; private set; }
		public int Length { get; private set; }
		public int Weight { get; private set; }
		//
		// Пушки и груз!!!!
		//
		public int Observation { get; private set; }
		public int Subtlety { get; private set; }
		public PartsScheme<int> Armour { get; private set; }
		public PartsScheme<int> HitPoints { get; private set; }
		public PartsScheme<int> NumberOfGuns { get; private set; }
		public int Sharpshooting { get; private set; }
		public int Speed { get; private set; }
		public TDimesions Dimensions { get; private set; }
		public int Luck { get; set; }
		public int Moral { get; set; }
		public int Initiative { get; set; }

		public class PartsScheme<T> {
			public T HullLeft { get; set; }
			public T HullRight { get; set; }
			public T HullTail { get; set; }
			public T HullHead { get; set; }
			public T Deck { get; set; }
			public T Mast { get; set; }
		}
		public class TDimesions {
			public int Draft { get; set; }
			public int BearingCapacity { get; set; }
		}
		public enum ShipClass {
			BattleShip = 1,
			Frigate,
			Carvette,
			Galley,
			Trader,
			Sloop,
			FishingBoat
		}	
		public enum TNation {
			England,
			Spain,
			Portugal,
			France,
			Brothers
		}

	}
	abstract class Cannon {
		public int Weight { get; set; }
		public int MaxCannonballWeight { get; set; }
		public TBaseShip.PartsScheme<int> Sharpshooting { get; set; }
	}
	abstract class CannonBall {
		public int Weight { get; set; }
		public int AirResistence { get; set; }
		public TBaseShip.PartsScheme<int> Damage { get; set; }
		public TBaseShip.PartsScheme<int> Sharpshooting { get; set; }
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
