using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemConcroller : MonoBehaviour {

	public Transform camera;
	public float distance = 3;
	public Material normalMaterial;
	public Material selectedMaterial;

	private RaycastHit hit;
	private bool isClick;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, camera.forward * distance, Color.black);

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (this.transform.position, camera.forward, out hit, distance)) {
			if (hit.transform.GetComponent<MeshRenderer> () && !hit.transform.CompareTag ("Ground")) {
				if (isClick) {
					isClick = false;
					hit.transform.GetComponent<MeshRenderer> ().material = selectedMaterial;
				}
				else {
					isClick = true;
					hit.transform.GetComponent<MeshRenderer> ().material = normalMaterial;
				}
			}
		}
	}


}

