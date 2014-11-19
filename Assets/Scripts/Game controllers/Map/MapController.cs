using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
class MapController: MonoBehaviour {
    private static MapController instance;
    [SerializeField]
	private Map map;
	public Material SeaSurface;
	public Material ShootToMaterial;
	public Material MoveToMaterial;

	double[,] residualLength;
	// TODO calibrate
	static double roundTime = 7;
	static double cellHeight = 5;

    public static MapController Instance(Map map = null)
    {
        if (instance == null)
        {
            instance = new MapController(map);
        }
        return instance;
    }

	public Map Map
	{
		get { return map; }
	}

	
	private MapController(Map map) {
		this.map = map;
		residualLength = new double[map.Width, map.Height];
	}
	
	public void Awake()
	{
        instance = this;
		residualLength = new double[Map.Width, Map.Height];
	}

	public List<Cell> CalculateAvailableMovingArea(Ship ship)
	{
		ship.CurrentCell.renderer.material = MoveToMaterial;
        List<Cell> area = Map.GetNeighbours(ship.CurrentCell, ship.Current.Parameters.Observation, (cell) => (cell.IsFree && cell.IsAvailableRouteCell));
		foreach(var neighbourCell in area)
		{
			neighbourCell.renderer.material = MoveToMaterial;
		}
        return area;
	}

	public List<Cell> CalculateAvailableShootingArea(Ship ship)
	{
		ship.CurrentCell.renderer.material = ShootToMaterial;
        List<Cell> area = Map.GetNeighbours(ship.CurrentCell, ship.Current.Parameters.Observation);
		foreach(var neighbourCell in area)
		{
			neighbourCell.renderer.material = ShootToMaterial;
		}
        return area;
	}

	/*
	public void CalculateAvailableArea(Ship ship, Cell cell)
	{
		for (int i = 0; i < residualLength.GetLength(0); i++)
			for (int j = 0; j < residualLength.GetLength(1); j++)
				residualLength[i, j] = 0;
		residualLength[cell.X, cell.Z] = ship.Current.Parameters.Speed * roundTime;
		int x = cell.X;
		int z = cell.Z;
		while (residualLength[x, z] != 0) {
			Map[x, z].IsAvailableRouteCell = true;
			Map[x, z].renderer.material = MoveToMaterial;
			var enumerator = Map.GetNeighbours(x, z).GetEnumerator();
			while (enumerator.MoveNext()) {
				int curX = enumerator.Current.X;
				int curY = enumerator.Current.Z;
				if (Map[curX, curY].IsFree)
				{
					residualLength[curX, curY] = System.Math.Max(residualLength[curX, curY], residualLength[x, z] - cellHeight / (1 - 0.5 * (Map[x, z].Bonus.Speed + Map[curX, curY].Bonus.Speed) / ship.Current.Parameters.Speed));
				}
			}
			
			for(int i = 0; i < residualLength.GetLength(0); i++)
				for (int j = 0; j < residualLength.GetLength(1); j++)
					if (Map[i, j].IsFree && !Map[i, j].IsAvailableRouteCell && (x < 0 || residualLength[i, j] > residualLength[x, z]))
					{
						x = i;
						z = j;
					}	
		}
	}
	*/
}