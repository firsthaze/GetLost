using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThreshold : MonoBehaviour {
    public float _weightThreshold;
    public bool _isFuctional;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetWeightThreshold()
    {
        return _weightThreshold;
    }

    public bool GetIsObjectCanMove(float electricCharge)
    {
        if (electricCharge > _weightThreshold)
            return true;
        else
            return false;
    }

    public bool GetIsFunctional()
    {
        return _isFuctional;
    }
}
