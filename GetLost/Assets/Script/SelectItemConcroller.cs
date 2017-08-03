using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemConcroller : MonoBehaviour {
    private GameObject EventSystem;
	public Transform camera;
	public float distance = 3;
    private GameObject Player;
	private RaycastHit hit;
    private Transform PlayerParent;
    private Transform WorldParent;
    private bool isReadyToBeUsed;
    private string ObjectName;

    // Use this for initialization
    void Start () {
        EventSystem = GameObject.Find("EventSystem");
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerParent = Player.GetComponent<Transform>();
        WorldParent = GameObject.FindGameObjectWithTag("World").GetComponent<Transform>();
        isReadyToBeUsed = false;
        ObjectName = "";
    }
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, camera.forward * distance, Color.black);
        GetItem();
        UseFunctionalItem();
	}

    void GetItem() {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("isgrab is : " + Player.GetComponent<Character>().GetIsGrabing());
            if (Physics.Raycast(this.transform.position, camera.forward, out hit, distance) && !Player.GetComponent<Character>().GetIsGrabing())
            {
                if (hit.transform.CompareTag("Item"))
                {
                    // 是否可以把物件拿起來  判斷Threshold
                    if (hit.transform.GetComponent<ObjectThreshold>().GetIsObjectCanMove(Player.GetComponent<Character>().GetEletricCharge()))
                    {
                        Player.GetComponent<Character>().SetIsGrabing(true);
                        hit.transform.tag = "Grabed";
                        hit.transform.SetParent(PlayerParent);
                        Debug.Log("get item");

                        // 該物件是否有功能可以使用
                        if (hit.transform.GetComponent<ObjectThreshold>().GetIsFunctional())
                        {
                            ObjectName = hit.transform.name;  //取得物件名稱 以供給Eventsystem使用
                            EventSystem.GetComponent<DisplayNoticeBoard>().ShowNoticeBoard();
                            isReadyToBeUsed = true;
                            Debug.Log("is ready to be use :" + ObjectName);
                        }
                    }
                }
            }
            else
            {
                if (GameObject.FindGameObjectWithTag("Grabed"))
                {
                    isReadyToBeUsed = false;
                    Player.GetComponent<Character>().SetIsGrabing(false);
                    EventSystem.GetComponent<DisplayNoticeBoard>().CloseNoticeBoard();
                    GameObject temp = GameObject.FindGameObjectWithTag("Grabed");
                    temp.transform.SetParent(WorldParent);
                    GameObject.FindGameObjectWithTag("Grabed").transform.tag = "Item";
                    Debug.Log("put down item");
                }
            }
        }
    }

    void UseFunctionalItem()
    {
        if (Input.GetKey(KeyCode.E) && isReadyToBeUsed)
        {
            EventSystem.GetComponent<FunctionController>().Use(ObjectName);
        }
    }
}

