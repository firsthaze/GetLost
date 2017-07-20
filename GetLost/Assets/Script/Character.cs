﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	private float _electricCharge;
    private bool isGrabing;
	//constructor
	public Character()
	{
		_electricCharge = 100f;
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

    public bool GetIsGrabing()
    {
        return isGrabing;
    }

    public void SetIsGrabing(bool isGrab)
    {
        isGrabing = isGrab;
    }
}