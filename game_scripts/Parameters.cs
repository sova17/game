using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	struct TParameters {
		public Int32 Observation { get; set; }
		public Int32 Subtlety { get; set; }
		public TShipParts Armour { get; set; }
		public TShipParts HitPoints { get; set; }
		public TShipParts NumberOfGuns { get; set; }
		public Int32 Sharpshooting { get; set; }
		public Int32 Speed { get; set; }
		public Int32 Draft { get; set; }
		public Int32 Weight { get; set; }
		public Int32 Luck { get; set; }
		public Int32 Moral { get; set; }
		public Int32 Initiative { get; set; }
	}
	struct TShipParts {
		public Int32 HullLeft { get; set; }
		public Int32 HullRight { get; set; }
		public Int32 HullTail { get; set; }
		public Int32 HullHead { get; set; }
		public Int32 Deck { get; set; }
		public Int32 Mast { get; set; }
		public static TShipParts operator +(TShipParts first, TShipParts second) {
			throw new NotImplementedException();
		}
	}
}
