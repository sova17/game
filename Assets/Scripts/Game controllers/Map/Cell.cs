using UnityEngine;

[System.Serializable]
class Cell: MonoBehaviour {
	public int X;
	public int Z;
	public int Depth;
	public Parameters Bonus;
	public Weather Weather;
	public bool IsAvailableRouteCell = false;
	public bool IsFree = true;

	public event System.Action<Cell> TryingToSelect;

	public override string ToString ()
	{
		return string.Format ("Cell[{0}, {1}]", X, Z);
	}

	public void OnMouseDown()
	{
        TryingToSelect(this);
	}
}