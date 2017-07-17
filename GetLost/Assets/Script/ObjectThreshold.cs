using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThreshold : MonoBehaviour {
    public float _weightThreshold;

	// Use this for initialization
	void Start () {
        _weightThreshold = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    float GetWeightThreshold()
    {
        return _weightThreshold;
    }

}
