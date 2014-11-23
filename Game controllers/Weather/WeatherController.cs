using UnityEngine;
using System;

[System.Serializable]
class WeatherController: MonoBehaviour {
	public void GenerateWeather(Map map) {
		for (int i = 0; i < (Math.Min(map.Width, map.Height) + 1) / 2; i++) {
			if (map.Width - 2 * i == 1) {
				for (int j = i; j < map.Height - i; j++)
					map[i, j].GetComponent<Cell>().Weather = Average(map, map[i, j]);
			}
			else if (map.Height - 2 * i == 1) {
				for (int j = i; j < map.Width - i; j++)
					map[j, i].GetComponent<Cell>().Weather = Average(map, map[j, i]);
			}
			else {
				for (int j = i; j < map.Width - i; j++) {
					map[j, i].GetComponent<Cell>().Weather = Average(map, map[j, i]);
					map[j, map.Height - i - 1].GetComponent<Cell>().Weather = Average(map, map[j, map.Height - i - 1]);
				}
				for (int j = i; j < map.Height - i; j++) {
					map[map.Width - i - 1, j].GetComponent<Cell>().Weather = Average(map, map[map.Width - i - 1, j]);
					map[i, j].GetComponent<Cell>().Weather = Average(map, map[i, j]);
				}
			}
		}
	}

	Weather Average(Map map, Cell cell) {
		var enumerator = map.GetNeighbours(cell, 1).GetEnumerator();
		Weather result = new Weather();
		int count = 0;
		while (enumerator.MoveNext()) {
			result += enumerator.Current.Weather;
			count++;
		}
		return result / count;
	}
}

