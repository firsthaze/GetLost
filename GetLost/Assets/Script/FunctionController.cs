using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionController : MonoBehaviour {
    public GameObject Player;
    public GameObject Body_Face;
    public GameObject Body_Body;

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
            default:
                Debug.Log("objectName can't find :" + objectName);
                break;
        }
    }

    void DoCharge()
    {
        if (Capacitance.gameObject.transform.GetComponent<CapacitanceOnce>().GetReaminGL() > 0) ;
        {
            float temp = Capacitance.gameObject.transform.GetComponent<CapacitanceOnce>().GetReaminGL();
            temp -= 0.02f;
            Player.gameObject.GetComponent<CharacterScaling>().Charge();
            Capacitance.gameObject.transform.GetComponent<CapacitanceOnce>().SetRemainGL(temp);
        }
    }
}
