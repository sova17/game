using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	class TBaseShipController {
		// how will ship be binded with cell ?
		///////////// TO DO /////////////
		private SortedSet<TShip> _ships;
		public TShip CurrentShip { get; private set; }
		public TBaseShipController(TAction wait, TAction defense, TAction rotate, TAction damage, TAction go) {
			this._ships = new SortedSet<TShip>();
			this.Wait = wait;
			this.Defense = defense;
			this.Rotate = rotate;
			this.Damage = damage;
			this.Go = go;
		}
		// obviously can be grouped in one array/List of actions if it will be needed
		public TAction Wait { get; protected set; }
		public TAction Defense { get; protected set; }
		public TAction Rotate { get; protected set; }
		public TAction Damage { get; protected set; }
		public TAction Go { get; protected set; }
		public void AddShip(TShip ship) {
			_ships.Add(ship);
		}
		public void SubShip(TShip ship) {
			_ships.Remove(ship);
		}
	}
}
