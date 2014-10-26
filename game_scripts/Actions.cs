using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TAction {
		public abstract void Execute(TBaseShipController shipController, params Object[] objects);
	}

	abstract class TBaseShipAction : TAction {
		public override void Execute(TBaseShipController shipController, params Object[] objects) {
			if (objects.Length != 2)
				throw new ArgumentException();
			Execute(shipController, (TShip)objects[0], objects[1]);
		}
		public abstract void Execute(TBaseShipController shipController, TShip ship, Object obj);
	}

	abstract class TBaseCellAction : TAction {
		public override void Execute(TBaseShipController shipController, Object[] objects) {
			if (objects.Length != 1)
				throw new ArgumentException();
			Execute(shipController, (TCell)objects[0]);
		}
		public abstract void Execute(TBaseShipController shipController, TCell cell);
	}

	class TDamageAction : TBaseShipAction {
		public override void Execute(TBaseShipController shipController, TShip ship, object obj) {
			Execute(shipController, ship, (TDirection)obj);
		}
		public void Execute(TBaseShipController shipController, TShip ship, TDirection direction) {
			throw new NotImplementedException();
			///////////// TO DO /////////////
		}
	}
	class TGoAction : TBaseCellAction {
		public override void Execute(TBaseShipController shipController, TCell cell) {
			if (!cell.IsAvailableRouteCell)
				throw new ArgumentOutOfRangeException();
			TShip ship = shipController.CurrentShip;
			shipController.SubShip(ship);
			ship.Current.Parameters -= cell.OnCurrentRouteBonus;
			shipController.AddShip(ship, cell);
		}
	}
}
