﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpSpeed = 10;
	public float lightningSpeed = 1000;
	public float gravity = 0.5f;
	public Transform camera;
	public Transform feet;

	private Vector3 playerVelocity;

	private Animator anim;
	private GroundSensor groundSensor;
	private CharacterController characterController;
	private Character character;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		groundSensor = feet.GetComponent<GroundSensor> ();
		characterController = GetComponent<CharacterController>();
		character = GetComponent<Character>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		feet.position = this.transform.position;
		playerVelocity -= Vector3.up * gravity * Time.deltaTime;

		if (character.GetIsGrabing())
			moveSpeed = 5;
		else
			moveSpeed = 10;

		//基本移動
		if (groundSensor.isGrounded) {
			if (Input.GetKey (KeyCode.W))
				playerVelocity = new Vector3 (camera.forward.x, 0.0f, camera.forward.z) * moveSpeed * Time.deltaTime;
			else if (Input.GetKey (KeyCode.S))
				playerVelocity = new Vector3 (camera.forward.x, 0.0f, camera.forward.z) * -moveSpeed * Time.deltaTime;
			else if (Input.GetKey (KeyCode.D))
				playerVelocity = new Vector3 (camera.right.x, 0.0f, camera.right.z) * moveSpeed * Time.deltaTime;
			else if (Input.GetKey (KeyCode.A))
				playerVelocity = new Vector3 (camera.right.x, 0.0f, camera.right.z) * -moveSpeed * Time.deltaTime;
			else
				playerVelocity = Vector3.zero;

			if (Input.GetKey (KeyCode.Space))
				playerVelocity += Vector3.up * jumpSpeed * Time.deltaTime;
		} 
			

		//扣血瞬移
		if (Input.GetKeyUp (KeyCode.Q) && character.LoseEletricCharge (1)) {
			if (Input.GetKey (KeyCode.W))
				characterController.Move (new Vector3 (camera.forward.x, 0.1f, camera.forward.z) * lightningSpeed * Time.deltaTime);
			else if (Input.GetKey (KeyCode.S))
				characterController.Move (new Vector3 (-camera.forward.x, 0.1f, -camera.forward.z) * lightningSpeed * Time.deltaTime);
			else if (Input.GetKey (KeyCode.D))
				characterController.Move (new Vector3 (camera.right.x, 0.1f, camera.right.z) * lightningSpeed * Time.deltaTime);
			else if (Input.GetKey (KeyCode.A))
				characterController.Move (new Vector3 (-camera.right.x, 0.1f, -camera.right.z) * lightningSpeed * Time.deltaTime);
			else if (!groundSensor.isGrounded)
				characterController.Move (new Vector3 (0, 1, 0) * lightningSpeed * Time.deltaTime);		
			else
				characterController.Move (new Vector3 (camera.forward.x, 0.1f, camera.forward.z) * lightningSpeed * Time.deltaTime);
		}
		
		anim.SetFloat ("Speed", playerVelocity.magnitude * 10);
		characterController.Move (playerVelocity);
		this.transform.rotation = Quaternion.Euler (0, camera.transform.rotation.eulerAngles.y, 0);
	}

}
