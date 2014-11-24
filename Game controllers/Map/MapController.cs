using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
class MapController : MonoBehaviour {
	private static MapController instance;
	[SerializeField]
	private Map map;
	public Material SeaSurface;
	public Material ShootToMaterial;
	public Material MoveToMaterial;

	double[,] residualLength;
	// TODO: calibrate
	static double roundTime = 12;
	//static double cellHeight = 5;

	public static MapController Instance(Map map = null) {
		if (instance == null) {
			instance = new MapController(map);
		}
		return instance;
	}

	public Map Map {
		get { return map; }
	}


	private MapController(Map map) {
		this.map = map;
		//residualLength = new double[map.Width, map.Height];
	}

	public void Awake() {
		instance = this;
		residualLength = new double[Map.Width, Map.Height];
		for (int i = 0; i < residualLength.GetLength(0); i++)
			for (int j = 0; j < residualLength.GetLength(1); j++)
				residualLength[i, j] = -1;
	}

	// old method:
	//public List<Cell> CalculateAvailableMovingArea(Ship ship) {
	//	ship.CurrentCell.renderer.material = MoveToMaterial;
	//	List<Cell> area = Map.GetNeighbours(ship.CurrentCell, ship.Current.Parameters.Observation, (cell) => (cell.IsFree && cell.IsAvailableRouteCell));
	//	area.Add(ship.CurrentCell);
	//	foreach (var neighbourCell in area) {
	//		neighbourCell.renderer.material = MoveToMaterial;
	//	}
	//	return area;
	//}

	public List<Cell> CalculateAvailableShootingArea(Ship ship) {
		ship.CurrentCell.renderer.material = ShootToMaterial;
		List<Cell> area = Map.GetNeighbours(ship.CurrentCell, ship.Current.Parameters.DefaultStepLength);
		foreach (var neighbourCell in area) {
			neighbourCell.renderer.material = ShootToMaterial;
		}
		return area;
	}


	public List<Cell> CalculateAvailableMovingArea(Ship ship) {
		// UPDATE: теперь не нужен, распределен между соответствующими Awake()
		// костыль для инициализации в первый раз, в дальнейшем не нужен из-за того
		// что алгоритм убирает за собой мусор
		//if(residualLength[0, 0] >= 0)
		//for (int i = 0; i < residualLength.GetLength(0); i++)
		//	for (int j = 0; j < residualLength.GetLength(1); j++) {
		//		residualLength[i, j] = -1;
		//		//Map[i, j].IsAvailableRouteCell = false;
		//	}
		int x = ship.CurrentCell.X;
		int z = ship.CurrentCell.Z;
		residualLength[x, z] = ship.Current.Parameters.Speed * roundTime;
		List<Cell> result = new List<Cell>();
		result.Add(ship.CurrentCell);
		while (x >= 0) {
			Map[x, z].IsAvailableRouteCell = true;
			Map[x, z].renderer.material = MoveToMaterial;
			List<Cell> neighbours = Map.GetNeighbours(Map[x, z], 1, (curCell) => {
				return curCell.IsFree && !result.Exists(cl => { return cl == curCell; });
			});
			foreach (var neighbour in neighbours) {
				int curX = neighbour.X;
				int curY = neighbour.Z;
				// UPDATE LENGTH CHANGING:
				//Weather weather = (neighbour.Weather + Map[x, z].Weather) / 2;
				//float resultAngle = Map.GetAngle(Map[x, z], neighbour);
				//float resultSpeed = GetSpeed(ship.Current.Parameters.Speed, resultAngle, weather);
				//if (resultSpeed <= 0)
				//	continue;
				//residualLength[curX, curY] = System.Math.Max(residualLength[curX, curY], residualLength[x, z] - Map.CellHeight * ship.Current.Parameters.Speed / resultSpeed);
				residualLength[curX, curY] = System.Math.Max(residualLength[curX, curY], residualLength[x, z] - Map.CellHeight);
				if (residualLength[curX, curY] >= 0)
					result.Add(neighbour);
			}

			x = -1;
			foreach (var item in result)
				if (item.IsFree && !item.IsAvailableRouteCell && (x < 0 || residualLength[item.X, item.Z] > residualLength[x, z])) {
					x = item.X;
					z = item.Z;
				}
		}
		// cleaning Map & residualLength for future using
		foreach (var item in result) {
			Map[item.X, item.Z].IsAvailableRouteCell = false;
			residualLength[item.X, item.Z] = -1;
		}
		return result;
	}

	private float GetSpeed(float speed, float resultAngle, Weather weather) {
		double delta = (float)Math.Asin(weather.WindSpeed / speed * Mathf.Sin(weather.Angle - resultAngle));
		if (delta == Double.NaN)
			return -1;
		return (float)(speed * Math.Cos(delta));
	}

}