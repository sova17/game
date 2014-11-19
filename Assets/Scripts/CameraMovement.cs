using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	// A very simplistic car driving on the x-z plane.
	float speed = -500.0f;
	float rotationSpeed = 100.0f;

	void Update()
	{
		transform.Translate (Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0, 0);
		transform.Rotate (0, Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime, 0);
	}
}