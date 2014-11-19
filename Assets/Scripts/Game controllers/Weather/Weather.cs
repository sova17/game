using UnityEngine;

class Weather: MonoBehaviour {
	public int WindSpeed;
	
	public static Weather operator +(Weather first, Weather second) {
		Weather weather = new Weather();
		weather.WindSpeed = first.WindSpeed + second.WindSpeed;
		return weather;
	}
	
	public static Weather operator / (Weather first, int num) {
		Weather weather = new Weather();
		weather.WindSpeed = first.WindSpeed / num;
		return weather;
	}
}