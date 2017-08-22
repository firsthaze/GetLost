using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacitanceOnce : MonoBehaviour {

    public float _remainGL;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetReaminGL()
    {
        return _remainGL;
    }

    public void SetRemainGL(float remainGL)
    {
        _remainGL = remainGL;
    }
}
