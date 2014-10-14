using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class CannonBall {
		public int Weight { get; set; }
		public int AirResistence { get; set; }
		public TBaseShip.PartsScheme<int> Damage { get; set; }
		public TBaseShip.PartsScheme<int> Sharpshooting { get; set; }
	}
}
