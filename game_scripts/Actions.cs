using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
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
}
