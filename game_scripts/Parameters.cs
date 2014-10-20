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
			TShipParts result = new TShipParts();
			result.Deck = first.Deck + second.Deck;
			result.HullHead = first.Deck + second.Deck;
			result.HullLeft = first.HullLeft + second.HullLeft;
			result.HullRight = first.HullRight + second.HullRight;
			result.HullTail = first.HullTail + second.HullTail;
			result.Mast = first.Mast + second.Mast;
			return result;
		}
		public static TShipParts operator -(TShipParts first, TShipParts second) {
			second.Deck *= -1;
			second.HullHead *= -1;
			second.HullLeft *= -1;
			second.HullRight *= -1;
			second.HullTail *= -1;
			second.Mast *= -1;
			return first + second;
		}
	}
}
