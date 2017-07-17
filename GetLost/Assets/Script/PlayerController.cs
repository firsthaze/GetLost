﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 500;
	public float jumpSpeed = 300;
	public Transform camera;

	private Vector3 playerVelocity;

	private Rigidbody rigidbody;
	private Animator anim;
	private GroundSensor groundSensor;

	// Use this for initialization
	void Start()
	{
		rigidbody = this.GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		groundSensor = this.transform.Find("Feet").GetComponent<GroundSensor>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		if (Input.GetKey(KeyCode.W))
			playerVelocity = new Vector3(camera.forward.x, 0.0f, camera.forward.z) * moveSpeed * Time.deltaTime;
		else if (Input.GetKey(KeyCode.S))
			playerVelocity = new Vector3(camera.forward.x, 0.0f, camera.forward.z) * -moveSpeed * Time.deltaTime;
		else if (Input.GetKey(KeyCode.D))
			playerVelocity = new Vector3(camera.right.x, 0.0f, camera.right.z) * moveSpeed * Time.deltaTime;
		else if (Input.GetKey(KeyCode.A))
			playerVelocity = new Vector3(camera.right.x, 0.0f, camera.right.z) * -moveSpeed * Time.deltaTime;
		else
			playerVelocity = Vector3.zero;

		if (Input.GetKey(KeyCode.Space) && groundSensor.isGround)
			playerVelocity = Vector3.up * jumpSpeed * Time.deltaTime;


		rigidbody.velocity = new Vector3(playerVelocity.x, rigidbody.velocity.y + playerVelocity.y, playerVelocity.z);

		anim.SetFloat("Speed", playerVelocity.magnitude);

		this.transform.rotation = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0);
	}

}
