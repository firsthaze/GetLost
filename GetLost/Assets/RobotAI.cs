using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAI : MonoBehaviour {

	private float rotateAngle;

	// Use this for initialization
	void Start () {
		rotateAngle = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x > 32)
			this.transform.Translate (Vector3.right * Time.deltaTime * -2);
		else {
			if (this.transform.Find ("Hand").transform.rotation.z >= 0.4 || this.transform.Find ("Hand").transform.rotation.z <= -0.4) {
				rotateAngle *= -1;
			}
			this.transform.Find ("Hand").transform.Rotate (0, 0, rotateAngle);
		}


	}
}
