using UnityEngine;

[System.Serializable]
class Cell : MonoBehaviour {
	public int X;
	public int Z;
	// public int Depth;
	/* BONUS CELLS ? */
	// public Parameters Bonus;
	public Weather Weather;
	public bool IsAvailableRouteCell = false;
	public bool IsFree = true;

	public event System.Action<Cell> TryingToSelect;

	public void OnMouseDown() {
		TryingToSelect(this);
	}

	public static bool operator ==(Cell first, Cell second) {
		return first.X == second.X && first.Z == second.Z;
	}
	public static bool operator !=(Cell first, Cell second) {
		return !(first == second);
	}

	public override bool Equals(object obj) {
		return Equals((Cell)obj);
	}
	public bool Equals(Cell cell) {
		return cell == this;
	}
	public override int GetHashCode() {
		return this.ToString().GetHashCode();
	}

	public override string ToString() {
		return string.Format("Cell[{0}, {1}]", X, Z);
	}

}