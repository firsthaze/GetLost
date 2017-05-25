using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 5;
	public Transform camera;

	private Transform cameraMoveDirection;
	private Vector3 moveVector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cameraMoveDirection.localRotation= Quaternion.Euler (0, camera.localRotation.y, 0);
	}
}
