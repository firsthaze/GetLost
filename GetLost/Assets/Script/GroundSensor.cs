using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour {

	public bool isGrounded;

	void OnTriggerStay(Collider other) {
		if(!other.CompareTag("Player"))
			isGrounded = true;
	}

	void OnTriggerExit(Collider other) {
		if (!other.CompareTag ("Player"))
			isGrounded = false;
	}

}
