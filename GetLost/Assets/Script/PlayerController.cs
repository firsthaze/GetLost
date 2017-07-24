using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpSpeed = 10;
	public float lightningSpeed = 1000;
	public float gravity = 0.5f;
	public Transform camera;

	private Vector3 playerVelocity;

	private Animator anim;
	private GroundSensor groundSensor;
	private CharacterController characterController;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		groundSensor = this.transform.Find("Feet").GetComponent<GroundSensor>();
		characterController = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (characterController.isGrounded) {
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
		} else
			playerVelocity -= Vector3.up * gravity * Time.deltaTime;

		if (Input.GetKeyUp (KeyCode.Q))
			characterController.Move (new Vector3 (camera.forward.x, 0.0f, camera.forward.z) * lightningSpeed * Time.deltaTime);	
		
		anim.SetFloat ("Speed", playerVelocity.magnitude * 10);
		characterController.Move (playerVelocity);
		this.transform.rotation = Quaternion.Euler (0, camera.transform.rotation.eulerAngles.y, 0);
	}

}
