using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalibleObject : MonoBehaviour {
    private bool isGrab;
	// Use this for initialization
	void Start () {
        isGrab = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("e"))
        {
        }
	}

    public void SetIsGrab(bool isGrab)
    {
        this.isGrab = isGrab;
    }

    public bool GetIsGrab()
    {
        return this.isGrab;
    }

    /*private UseObject()
    {
    }*/
}
