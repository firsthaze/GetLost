using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour {

	public Transform player;
	//攝影機高度
	public float height = 2;

	//攝影機角度
	public float x = 0;
	public float y = 15;

	//攝影機移動速度
	public float xSpeed = 100;
	public float ySpeed = 30;

	//攝影機離玩家的距離
	public float distance = 10;

	//原始玩家高度
	private float originPlayerHeight;

	// Use this for initialization
	void Start()
	{
		originPlayerHeight = player.localScale.y;
	}

	// Update is called once per frame
	void Update()
	{
		Cursor.visible = false;

		//角度隨著滑鼠移動增減
		x += Input.GetAxis ("Mouse X") * xSpeed * Time.deltaTime;
		y -= Input.GetAxis ("Mouse Y") * ySpeed * Time.deltaTime;

		//控制角度在合理範圍
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

		//攝影機移動與旋轉
		float currentPlayerHeight = height * (player.localScale.y / originPlayerHeight);
		float currentDistance = distance * (player.localScale.y / originPlayerHeight);
		transform.position = Quaternion.Euler (y, x, 0) * new Vector3 (0, currentPlayerHeight, -currentDistance) + player.position;
		transform.rotation = Quaternion.Euler (y, x, 0);
	}


}
