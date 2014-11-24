using UnityEngine;

class Weather : MonoBehaviour {
	public float WindSpeed;
	public float Angle;

	public static Weather operator +(Weather first, Weather second) {
		Weather weather = new Weather();
		float windX = first.WindSpeed * Mathf.Cos(first.Angle) + second.WindSpeed * Mathf.Cos(second.Angle);
		float windY = first.WindSpeed * Mathf.Sin(first.Angle) + second.WindSpeed * Mathf.Sin(second.Angle);
		weather.WindSpeed = Mathf.Sqrt(windX * windX + windY * windY);
		weather.Angle = Mathf.Atan2(windY, windX) * Mathf.PI;
		if (windY < 0)
			weather.Angle += 180;
		return weather;
	}

	public static Weather operator /(Weather first, int num) {
		Weather weather = new Weather();
		weather.WindSpeed = first.WindSpeed / num;
		weather.Angle = first.Angle;
		return weather;
	}
}