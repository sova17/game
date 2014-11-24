using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	float speed = -500.0f;
	float rotationSpeed = 100.0f;

	void Update()
	{
		transform.Translate (Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0, 0);
		transform.Rotate (0, Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime, 0);
	}
}