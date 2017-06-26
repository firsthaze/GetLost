using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour {

	public bool isGround;

	void OnTriggerEnter(Collider other) {
		isGround = true;
	}

	void OnTriggerExit(Collider other) {
		isGround = false;
	}

}
