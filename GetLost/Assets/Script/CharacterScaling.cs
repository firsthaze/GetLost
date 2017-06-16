using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterScaling : MonoBehaviour {
	Character characterInfo;
	private Vector3 temp;
	private float characterVolume;
	public float chargeSpeed;
	// Use this for initialization
	void Start () {
		chargeSpeed = 5f;
		characterInfo = new Character ();
		characterVolume = characterInfo.GetEletricCharge ();
	}
	
	// Update is called once per frame
	void Update () {
		temp = transform.localScale;
		if (characterInfo.GetEletricCharge() <= 130f)
			Scaling ();
	}

	void Scaling(){
		characterVolume += Time.deltaTime * chargeSpeed;
		characterInfo.SetEletricCharge (characterVolume);
		temp.x += Time.deltaTime;
		temp.y += Time.deltaTime;
		temp.z += Time.deltaTime;
		transform.localScale = temp;
	}
}
