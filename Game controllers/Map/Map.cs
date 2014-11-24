using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
class Map : MonoBehaviour, IEnumerable<Cell> {
	Cell[,] Cells;
	public int _width;
	public int _height;
	public float _cellHeight;
	public float CellHeight {
		get { return _cellHeight; }
		protected set { _cellHeight = value; }
	}
	private static int[,] _angles = { { -1, 180, 120 }, { 240, 0, 60 }, { 300, 0, -1 } };
	public int Width {
		get { return _width; }
		protected set { _width = value; }
	}
	public int Height {
		get { return _height; }
		set { _height = value; }
	}

	public Cell this[int x, int y] {
		get {
			if (x >= 0 && x < Width && y >= 0 && y < Height)
				return Cells[x, y];
			else
				throw new System.IndexOutOfRangeException();
		}
		set {
			if (x >= 0 && x < Width && y >= 0 && y < Height)
				Cells[x, y] = value;
			else
				throw new System.IndexOutOfRangeException();
		}
	}

	public void Awake() {
		_cellHeight = 5;
		Cells = new Cell[Width, Height];
		GameObject[] cellGOs = GameObject.FindGameObjectsWithTag(Tags.Cell);
		foreach (var cellGO in cellGOs) {
			Cell cell = cellGO.GetComponent<Cell>();
			Cells[cell.X, cell.Z] = cell;
			cell.IsAvailableRouteCell = false;
		}
	}

	private IEnumerable<Cell> getCells() {
		for (int x = 0; x < Width; x++)
			for (int z = 0; z < Height; z++)
				yield return this[x, z];
	}

	public IEnumerator<Cell> GetEnumerator() {
		return getCells().GetEnumerator();
	}
	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}

	public List<Cell> GetNeighbours(Cell cell, int radius, System.Func<Cell, bool> hasProperty = null) {
		int x = cell.X, z = cell.Z;
		List<Cell> area = new List<Cell>();
		for (int i = 0; i < Width; i++)
			for (int j = 0; j < Height; j++)
				if (Mathf.Abs(i - x + j - z) <= radius && Mathf.Abs(x - i) <= radius && Mathf.Abs(z - j) <= radius
					// it shouldn't work: 
					// if ((3.0/4.0 * (x - i) * (x - i) + (z - j + (x - i) / 2.0) * (z - j + (x - i) / 2.0) <= radius * radius)

					//we shouldn't return cell (x, z)
					 && (i != x || j != z) && (hasProperty != null ? hasProperty(this[i, j]) : true)) {
					area.Add(this[i, j]);
				}
		return area;
	}


	public int GetAngle(Cell begin, Cell end) {
		return _angles[begin.X - end.X + 1, begin.Z - end.Z + 1];
	}

	/*
	public Map(int width, int height) {
		this.Width = width;
		this.Height = height;
		//this.Cells = new Cell[width, height];
	}
	*/
}