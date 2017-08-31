using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpSpeed = 10;
	public float lightningSpeed = 1000;
	public float gravity = 0.5f;
	public Transform camera;
	public Transform feet;

	private Vector3 moveVelocity;
	private Vector3 otherVelocity;
	private Vector3 playerVelocity;

	private Animator anim;
	private GroundSensor groundSensor;
	private CharacterController characterController;
	private Character character;

	//避免偶爾會連跳2次的問題
	private bool jumpLock = false;

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

		if (character.GetIsGrabing ())
			moveSpeed = 5;
		else
			moveSpeed = 10;

		//基本移動，控制moveVelocity
		if (Input.GetKey (KeyCode.W))
			moveVelocity = new Vector3 (camera.forward.x, 0.0f, camera.forward.z) * moveSpeed * Time.deltaTime;
		else if (Input.GetKey (KeyCode.S))
			moveVelocity = new Vector3 (camera.forward.x, 0.0f, camera.forward.z) * -moveSpeed * Time.deltaTime;
		else if (Input.GetKey (KeyCode.D))
			moveVelocity = new Vector3 (camera.right.x, 0.0f, camera.right.z) * moveSpeed * Time.deltaTime;
		else if (Input.GetKey (KeyCode.A))
			moveVelocity = new Vector3 (camera.right.x, 0.0f, camera.right.z) * -moveSpeed * Time.deltaTime;
		else
			moveVelocity = Vector3.zero;


		//跳躍與落下，歸類到otherVelocity
		if (groundSensor.isGrounded) {
			if (otherVelocity.y < 0)
				otherVelocity = Vector3.zero;
			if (Input.GetKeyDown (KeyCode.Space) && !jumpLock) {
				jumpLock = true;
				otherVelocity += Vector3.up * jumpSpeed * Time.deltaTime;
			}
		} else {
			jumpLock = false;
			otherVelocity -= Vector3.up * gravity * Time.deltaTime;
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

		//把各向量加總
		playerVelocity = moveVelocity + otherVelocity;

		anim.SetFloat ("Speed", playerVelocity.magnitude * 10);
		characterController.Move (playerVelocity);
		this.transform.rotation = Quaternion.Euler (0, camera.transform.rotation.eulerAngles.y, 0);
	}

	public void BeenHitBack(Vector3 monsterPosion, float distance) {
		otherVelocity += (this.transform.position - monsterPosion) * distance * Time.deltaTime;
		otherVelocity += Vector3.up * 5 * Time.deltaTime;
	}

}
