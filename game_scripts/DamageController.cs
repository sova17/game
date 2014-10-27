using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseDamageController {
		public abstract TParameters CalculateDamage(TShip damager, TShip defenser, TDirection direction);
	}
	class TDamageController : TBaseDamageController {
		public override TParameters CalculateDamage(TShip damager, TShip defenser, TDirection direction) {
			// TODO
			throw new NotImplementedException();
		}
	}
	enum TDirection {
		Left,
		Right,
		Tail,
		Head,
		Air
	}
}
