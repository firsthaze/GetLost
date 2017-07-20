using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemConcroller : MonoBehaviour {

	public Transform camera;
	public float distance = 3;

    private GameObject Player;
	private RaycastHit hit;
    private Transform PlayerParent;
    private Transform WorldParent;
    private bool isGrab;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerParent = Player.GetComponent<Transform>();
        WorldParent = GameObject.FindGameObjectWithTag("World").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, camera.forward * distance, Color.black);
        GetItem();
	}

    void GetItem() {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("isgrab is : " + Player.GetComponent<Character>().GetIsGrabing());
            if (Physics.Raycast(this.transform.position, camera.forward, out hit, distance) && !Player.GetComponent<Character>().GetIsGrabing())
            {
                if (hit.transform.CompareTag("Item"))
                {
                    Player.GetComponent<Character>().SetIsGrabing(true);
                    hit.transform.tag = "Grabed";
                    hit.transform.SetParent(PlayerParent);
                    Debug.Log("get item");
                }
            }
            else
            {
                if (GameObject.FindGameObjectWithTag("Grabed"))
                {
                    Player.GetComponent<Character>().SetIsGrabing(false);
                    GameObject temp = GameObject.FindGameObjectWithTag("Grabed");
                    temp.transform.SetParent(WorldParent);
                    GameObject.FindGameObjectWithTag("Grabed").transform.tag = "Item";
                    Debug.Log("put down item");
                }
            }
        }
    }


}

