using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EletricChargeDisplay : MonoBehaviour {
    private float _hp;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        _hp = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Character>().GetEletricCharge();
        DisplayHP(_hp);
    }

    void DisplayHP(float hp){
        this.transform.gameObject.GetComponent<Text>().text = "" + hp;
    }

}
