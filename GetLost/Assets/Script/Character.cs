﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	private float _electricCharge;
    private bool isGrabing;
	//constructor
	public Character()
	{
		_electricCharge = 30f;
        isGrabing = false;

    }
	public float GetEletricCharge()
	{
		return _electricCharge;
	}

	public void SetEletricCharge(float electricCharge)
	{
		_electricCharge = electricCharge;
	}

	public bool LoseEletricCharge(float lostElectricCharge)
	{
		if (_electricCharge > lostElectricCharge) {
			_electricCharge -= lostElectricCharge;
			return true;
		} else {
			Debug.Log ("電力不足" + lostElectricCharge);
			return false;
		}
	}

    public bool GetIsGrabing()
    {
        return isGrabing;
    }

    public void SetIsGrabing(bool isGrab)
    {
        isGrabing = isGrab;
    }
}