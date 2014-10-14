using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseDamageController {
		public abstract int CalculateDamage(TBaseShip damager, TBaseShip defenser, TDirection direction);
	}
	enum TDirection {
		Left,
		Right,
		Tail,
		Head
	}
}
