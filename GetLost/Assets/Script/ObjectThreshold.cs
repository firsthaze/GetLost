using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThreshold : MonoBehaviour {
    public float _heightThreshold;
    public float _weightThreshold;

	// Use this for initialization
	void Start () {
        _heightThreshold = 0f;
        _weightThreshold = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    float GetHeightThreshold()
    {
        return _heightThreshold;
    }

    float GetWeightThreshold()
    {
        return _weightThreshold;
    }

}
