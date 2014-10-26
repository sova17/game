﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	class TWeatherController {
		public void GenerateWeather(TMap map) {
			for (int i = 0; i < (Math.Min(map.Width, map.Height) + 1) / 2; i++) {
				if (map.Width - 2 * i == 1) {
					for (int j = i; j < map.Height - i; j++)
						map[i, j].Weather = Average(map, i, j);
				}
				else if (map.Height - 2 * i == 1) {
					for (int j = i; j < map.Width - i; j++)
						map[j, i].Weather = Average(map, j, i);
				}
				else {
					for (int j = i; j < map.Width - i; j++) {
						map[j, i].Weather = Average(map, j, i);
						map[j, map.Height - i - 1].Weather = Average(map, j, map.Height - i - 1);
					}
					for (int j = i; j < map.Height - i; j++) {
						map[map.Width - i - 1, j].Weather = Average(map, map.Width - i - 1, j);
						map[i, j].Weather = Average(map, i, j);
					}
				}
			}
		}
		private TWeather Average(TMap map, Int32 x, Int32 y) {
			TWeather result = new TWeather();
			return (
				(x - 1 >= 0 ? map[x - 1, y].Weather : new TWeather()) +
				(x + 1 < map.Width ? map[x + 1, y].Weather : new TWeather()) +
				(y - 1 >= 0 ? map[x, y - 1].Weather : new TWeather())+
				(y + 1 < map.Height ? map[x, y + 1].Weather : new TWeather())
				) / 4 +
				(
				(x - 1 >= 0 && y - 1 >= 0 ? map[x - 1, y -1].Weather : new TWeather()) +
				(x - 1 >= 0 && y + 1 < map.Height ? map[x - 1, y + 1].Weather : new TWeather()) +
				(x + 1 < map.Width && y - 1 >= 0 ? map[x + 1, y - 1].Weather : new TWeather()) +
				(x + 1 < map.Width && y + 1 < map.Height ? map[x + 1, y + 1].Weather : new TWeather())
				) / 8;

		}
		}
		class TWeather {
			public Int32 WindSpeed { get; set; }
			public static TWeather operator +(TWeather first, TWeather second) {
				TWeather weather = new TWeather();
				weather.WindSpeed = first.WindSpeed + second.WindSpeed;
				return weather;
			}
			public static TWeather operator /(TWeather first, int num) {
				TWeather weather = new TWeather();
				weather.WindSpeed = first.WindSpeed / num;
				return weather;
			}
		}
}

