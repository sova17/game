using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	class TBaseShipController {
		private SortedSet<Tuple<TShip, TCell>> _ships;
		private SortedSet<Tuple<TShip, TCell>> _nextStepShips;
		private bool IsRoundPlay;
		public TShip CurrentShip { get; protected set; }
		public TMap Map { get; protected set; }
		public TMapController MapController { get; protected set; }
		public TBaseShipController(TAction wait, TAction defense, TAction rotate, TAction damage, TAction go) {
			this._ships = new SortedSet<Tuple<TShip, TCell>>();
			this.Wait = wait;
			this.Defense = defense;
			//this.Rotate = rotate;
			this.Damage = damage;
			this.Go = go;
		}
		// obviously can be grouped in one array/List of actions if it will be needed
		public TAction Wait { get; protected set; }
		public TAction Defense { get; protected set; }
		//public TAction Rotate { get; protected set; }
		public TAction Damage { get; protected set; }
		public TAction Go { get; protected set; }
		public void AddShip(TShip ship, TCell cell) {
			if (!IsRoundPlay)
				_ships.Add(new Tuple<TShip, TCell>(ship, cell));
			else
				_nextStepShips.Add(new Tuple<TShip, TCell>(ship, cell));
			Map[cell.X, cell.Y].IsFree = false;
		}
		public void SubShip(TShip ship) {
			_ships.RemoveWhere(new Predicate<Tuple<TShip, TCell>>(tuple => {
				Map[tuple.Item2.X, tuple.Item2.Y].IsFree = true;
				return tuple.Item1.Equals(ship);
			}));
		}
	}
}
