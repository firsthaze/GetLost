﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterScaling : MonoBehaviour {
	private Character characterInfo;
	private Vector3 tempForScale;
	private float eletricCharge;  //生命值
	public float chargeSpeed;    //生命值回復速度
    private float dischargeSpeed; //生命值減少速度
    public float chargeRate;     //玩家體積放大
    private float dischargeRate;  //玩家體積減小
	// Use this for initialization
	void Start ()
    {
		chargeSpeed = 1f;
        dischargeSpeed = 0.1f;
        chargeRate = 0.05f;
        dischargeRate = 0.0002f;
        characterInfo = this.GetComponent<Character>();
        eletricCharge = characterInfo.GetEletricCharge ();
        tempForScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Discharge();
	}

    /*void Scaling(){
		eletricCharge += Time.deltaTime * chargeSpeed;
		characterInfo.SetEletricCharge (eletricCharge);
		temp.x += Time.deltaTime;
		temp.y += Time.deltaTime;
		temp.z += Time.deltaTime;
		transform.localScale = temp;
	}*/


    public void Charge()
    {
        eletricCharge = characterInfo.GetEletricCharge();
        eletricCharge += chargeSpeed;
        characterInfo.SetEletricCharge(eletricCharge);
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
        eletricCharge = characterInfo.GetEletricCharge();
        eletricCharge -= Time.deltaTime * dischargeSpeed;
        characterInfo.SetEletricCharge(eletricCharge);
        if (eletricCharge > 100)
        {
            tempForScale.x -= dischargeRate;
            tempForScale.y -= dischargeRate;
            tempForScale.z -= dischargeRate;
        }
        else if (eletricCharge <= 100 && eletricCharge > 40)
        {
            tempForScale.x -= (dischargeRate / 2);
            tempForScale.y -= (dischargeRate / 2);
            tempForScale.z -= (dischargeRate / 2);
        }
        else if (eletricCharge <=  0 || (transform.localScale.x <= 0))
        {
            tempForScale.x = 0;
            tempForScale.y = 0;
            tempForScale.z = 0;
        }

        transform.localScale = tempForScale;
    }
}
