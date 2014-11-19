using UnityEngine;

[System.Serializable]
class ShipParts: MonoBehaviour {
	public int HullLeft;
	public int HullRight;
	public int HullTail;
	public int HullHead;
	public int Deck;
	public int Mast;
	
	public static ShipParts operator +(ShipParts first, ShipParts second) {
		ShipParts result = new ShipParts();
		result.Deck = first.Deck + second.Deck;
		result.HullHead = first.Deck + second.Deck;
		result.HullLeft = first.HullLeft + second.HullLeft;
		result.HullRight = first.HullRight + second.HullRight;
		result.HullTail = first.HullTail + second.HullTail;
		result.Mast = first.Mast + second.Mast;
		return result;
	}
	
	public static ShipParts operator -(ShipParts first, ShipParts second) {
		second.Deck *= -1;
		second.HullHead *= -1;
		second.HullLeft *= -1;
		second.HullRight *= -1;
		second.HullTail *= -1;
		second.Mast *= -1;
		return first + second;
	}
	
	public static bool operator ==(ShipParts first, ShipParts second) {
		return first.Equals(second);	
	}
	
	public static bool operator !=(ShipParts first, ShipParts second) {
		return !(first == second);
	}
	
	public static double operator /(ShipParts first, ShipParts second) {
		return Sum(first) / Sum(second);
	}
	
	
	static int Sum(ShipParts first) {
		return first.Deck + first.HullHead + first.HullLeft + first.HullRight + first.HullTail + first.Mast;
	}
	
	public override bool Equals(object obj) {
		if(obj is ShipParts)
			return Equals((ShipParts)obj);
		return false;
	}
	
	public bool Equals(ShipParts second) {
		return Deck == second.Deck &&
			HullHead == second.HullHead &&
				HullLeft == second.HullLeft &&
				HullRight == second.HullRight &&
				HullTail == second.HullTail &&
				Mast == second.Mast;
	}
	
	public override int GetHashCode() {
		return HullHead ^
			HullLeft ^
				HullRight ^
				HullTail ^
				Mast ^
				Deck;
	}
}