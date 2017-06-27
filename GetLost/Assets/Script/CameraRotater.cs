using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour {

	public float x;
	public float y;
	public float xSpeed = 100;
	public float ySpeed = 30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x += Input.GetAxis ("Mouse X") * xSpeed * Time.deltaTime;
		y -= Input.GetAxis ("Mouse Y") * ySpeed * Time.deltaTime;

		if(x > 360) {
			x -= 360;
		} else if (x < 0){
			x += 360;
		}

		transform.rotation = Quaternion.Euler (y, x, 0);
	}
}
