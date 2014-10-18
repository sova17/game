using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class CannonBall : IStorable {
		public abstract String GetName();
		public abstract TCapacity Capacity {get; }
		public Int32 AirResistence { get; set; }
		public ShipPartsScheme<Int32> Damage { get; set; }
		public ShipPartsScheme<Int32> Sharpshooting { get; set; }
	}
}
