using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionController : MonoBehaviour {
    public GameObject Player;
    public GameObject Body_Face;
    public GameObject Body_Body;
    public GameObject CapacitanceLength;
    public GameObject Capacitance;
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
            case "capacitance_60_once":
                Capacitance = GameObject.Find("capacitance_60_once");
                DoCharge();
                break;
            case "capacitance_unlimit":
                Capacitance = GameObject.Find("capacitance_unlimit");
                DoChargeUnlimit();
                break;
            default:
                Debug.Log("objectName can't find :" + objectName);
                break;
        }
    }

    void DoCharge()
    {

        if (Capacitance.gameObject.transform.GetComponent<CapacitanceOnce>().GetReaminGL() > 0) 
        {
            CapacitanceLength = Capacitance.gameObject.transform.GetChild(0).gameObject;
            float temp = Capacitance.gameObject.transform.GetComponent<CapacitanceOnce>().GetReaminGL();
            Debug.Log("GetReaminGL : " + temp);
            temp -= 3f;
            Player.gameObject.GetComponent<CharacterScaling>().Charge();
            Capacitance.gameObject.transform.GetComponent<CapacitanceOnce>().SetRemainGL(temp);
            CapacitanceLength.transform.localScale = new Vector3(1, 1, (temp+2.95f) / 60);
        }
    }

    void DoChargeUnlimit()
    {
        /*
        if ()
        {
            
        }*/
    }
}
