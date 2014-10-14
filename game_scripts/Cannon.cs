using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class Cannon {
		public int Weight { get; set; }
		public int MaxCannonballWeight { get; set; }
		public TBaseShip.PartsScheme<int> Sharpshooting { get; set; }
	}
}
