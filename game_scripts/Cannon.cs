using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class Cannon : IStorable {
		public abstract String GetName();
		public abstract TDimensions GetDimensions();
		public Int32 MaxCannonballWeight { get; set; }
		public ShipPartsScheme<Int32> Sharpshooting { get; set; }
	}
}
