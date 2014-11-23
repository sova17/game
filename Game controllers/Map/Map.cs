using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
class Map: MonoBehaviour, IEnumerable<Cell> {
  	Cell[,] Cells;
	public int _width;
	public int _height;

	public int Width
	{
		get { return _width; }
		protected set { _width = value; }
	}
	public int Height
	{
		get {  return _height; }
		set  { _height = value; }
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

	private IEnumerable<Cell> getCells()
	{
		for (int x = 0; x < Width; x++)
			for (int z = 0; z < Height; z++)
				yield return this[x, z];
	}

	IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator()
	{
		return getCells().GetEnumerator();
	}
	IEnumerator IEnumerable.GetEnumerator()
	{
		return getCells().GetEnumerator();
	}

	public Map(int width, int height) {
		this.Width = width;
		this.Height = height;
		this.Cells = new Cell[width, height];
	}

	public void Awake()
	{
		Cells = new Cell[Width, Height];
		GameObject[] cellGOs = GameObject.FindGameObjectsWithTag(Tags.Cell);
		foreach(var cellGO in cellGOs)
		{
			Cell cell = cellGO.GetComponent<Cell>();
			Cells[cell.X, cell.Z] = cell;
		}
	}

	public List<Cell> GetNeighbours(Cell cell, int radius, System.Func<Cell, bool> hasProperty = null)
	{
        int x = cell.X, z = cell.Z;
        List<Cell> area = new List<Cell>();
		for (int i = 0; i < Width; i++)
			for (int j = 0; j < Height; j++)
				if ((3.0/4.0 * (x - i) * (x - i) + (z - j + (x - i) / 2.0) * (z - j + (x - i) / 2.0) <= radius * radius)
                    && (i >=0 && i < this.Width) && (j >= 0 && j < this.Height) && (hasProperty != null ? hasProperty(this[i,j]) : true))
				{
                    area.Add(this[i, j]);
				}
        return area;
	}
}