using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour {

	public Transform player;
	public float x = 0;
	public float y = 15;
	public float xSpeed = 100;
	public float ySpeed = 30;
	public float distance = 10;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Cursor.visible = false;

		x += Input.GetAxis ("Mouse X") * xSpeed * Time.deltaTime;
		y -= Input.GetAxis ("Mouse Y") * ySpeed * Time.deltaTime;

		if (x > 360) {
			x -= 360;
		} else if (x < 0) {
			x += 360;
		}

		if (y > 360) {
			y -= 360;
		} else if (y < 0) {
			y += 360;
		}

		transform.position = Quaternion.Euler (y, x, 0) * new Vector3 (0, 1, -distance) + player.position;
		transform.rotation = Quaternion.Euler (y, x, 0);
	}

}
