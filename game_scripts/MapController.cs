using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseMapController {
		public abstract void CalculateAvailableArea(TMap map);
	}
}