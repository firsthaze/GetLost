using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionController : MonoBehaviour {
    public GameObject Player;
    public GameObject Body_Face;
    public GameObject Body_Body;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Use(string objectName)
    {
        switch (objectName)
        {
            case "Capacity":
                DoCharge();
                break;
            default:
                Debug.Log("objectName can't find :" + objectName);
                break;
        }
    }

    void DoCharge()
    {
        Player.gameObject.GetComponent<CharacterScaling>().Charge();
    }
}
