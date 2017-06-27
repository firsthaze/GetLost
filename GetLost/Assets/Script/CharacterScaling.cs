using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterScaling : MonoBehaviour {
	private Character characterInfo;
	private Vector3 tempForScale;
	private float characterVolume;
	private float chargeSpeed;
    private float dischargeSpeed;
    private float chargeRate;
    private float dischargeRate;
	// Use this for initialization
	void Start ()
    {
		chargeSpeed = 1f;
        dischargeSpeed = 0.5f;
        chargeRate = 0.05f;
        dischargeRate = 0.001f;
        characterInfo = new Character ();
		characterVolume = characterInfo.GetEletricCharge ();
        tempForScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Discharge();
	}

    /*void Scaling(){
		characterVolume += Time.deltaTime * chargeSpeed;
		characterInfo.SetEletricCharge (characterVolume);
		temp.x += Time.deltaTime;
		temp.y += Time.deltaTime;
		temp.z += Time.deltaTime;
		transform.localScale = temp;
	}*/

    private void OnMouseDrag()
    {
        Charge();
    }

    private void Charge()
    {
        characterVolume = characterInfo.GetEletricCharge();
        characterVolume += chargeSpeed;
        characterInfo.SetEletricCharge(characterVolume);
        if (tempForScale.x > 3)
        {
            tempForScale.x = 3;
            tempForScale.y = 3;
            tempForScale.z = 3;
        }
        else
        {
            tempForScale.x += chargeRate;
            tempForScale.y += chargeRate;
            tempForScale.z += chargeRate;
        }
        transform.localScale = tempForScale;
    }

    private void Discharge(){
        characterVolume = characterInfo.GetEletricCharge();
        characterVolume -= Time.deltaTime * dischargeSpeed;
        characterInfo.SetEletricCharge(characterVolume);
        if (characterVolume > 100)
        {
            tempForScale.x -= dischargeRate;
            tempForScale.y -= dischargeRate;
            tempForScale.z -= dischargeRate;
        }
        else if (characterVolume <= 100 && characterVolume > 40)
        {
            tempForScale.x -= (dischargeRate / 2);
            tempForScale.y -= (dischargeRate / 2);
            tempForScale.z -= (dischargeRate / 2);
        }
        else if (characterVolume <=  0 || (transform.localScale.x <= 0))
        {
            tempForScale.x = 0;
            tempForScale.y = 0;
            tempForScale.z = 0;
        }

        transform.localScale = tempForScale;
    }
}
