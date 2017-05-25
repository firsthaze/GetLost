//CameraController.cs for UnityChan
//Original Script is here:
//TAK-EMI / CameraController.cs
//https://gist.github.com/TAK-EMI/d67a13b6f73bed32075d
//https://twitter.com/TAK_EMI
//
//Revised by N.Kobayashi 2014/5/15 
//Change : To prevent rotation flips on XY plane, use Quaternion in cameraRotate()
//Change : Add the instrustion window
//Change : Add the operation for Mac
//




using UnityEngine;
using System.Collections;

namespace CameraController
{
	public class CameraController : MonoBehaviour
	{
		public GameObject player;

		private GameObject cameraObject;
		private Vector3 distance;

		void Start ()
		{
			cameraObject = this.transform.GetChild (0).gameObject;
			distance = this.transform.position - this.cameraObject.transform.position;
		}
	
		void FixedUpdate ()
		{
			this.followPlayer ();
			this.mouseEvent();
			return;
		}

		void followPlayer()
		{
			Vector3 cameraPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z) + distance;
			this.transform.position = Vector3.Lerp (transform.position, cameraPos, Time.deltaTime * 10);
		}

		void mouseEvent()
		{
			float delta = Input.GetAxis("Mouse ScrollWheel");
			if (delta != 0.0f)
				this.mouseWheelEvent(delta);
		}

		//Dolly 滾輪拉視窗大小
		public void mouseWheelEvent(float delta)
		{
			if ((distance.magnitude > 2 && delta < 0) || (distance.magnitude < 12 && delta > 0))
				distance *= (1.0f + delta);
			cameraObject.transform.position += distance;
		}

		public void cameraRotate(Vector3 eulerAngle)
		{

			this.transform.Rotate (new Vector3(30, 30, 30));
		}
	}
}
