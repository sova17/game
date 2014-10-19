using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseWeatherController {
		public abstract void GenerateWeather(TMap map);
	}
	class TWeather {
		public int WindSpeed { get; set; }
	}	
}
