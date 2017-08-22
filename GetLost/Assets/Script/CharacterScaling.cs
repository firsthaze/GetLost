using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterScaling : MonoBehaviour {
	private Character characterInfo;
	private Vector3 tempForScale;
	private float eletricCharge;  //生命值
	public float chargeSpeed;    //生命值回復速度
    private float dischargeSpeed; //生命值減少速度
    public float chargeRate;     //玩家體積放大
    private float dischargeRate;  //玩家體積減小
    private GameObject grabObject; // 抓住的物件
    public GameObject[] Bodys; // 實際要放大縮小的物件
    Vector3 distance;
    // Use this for initialization
    void Start ()
    {
		chargeSpeed = 1f;
        dischargeSpeed = 0.1f;
        chargeRate = 0.02f;
        dischargeRate = 0.0002f;
        characterInfo = this.GetComponent<Character>();
        eletricCharge = characterInfo.GetEletricCharge ();
        tempForScale = transform.localScale;
        Scaling();
    }
	
	// Update is called once per frame
	void Update ()
    {
       // Discharge();
        Scaling();
    }

    void Scaling(){
        grabObject = GameObject.FindGameObjectWithTag("Grabed");
        eletricCharge = characterInfo.GetEletricCharge();
        float tempCharge = eletricCharge / 10;
        float tempScale = (((tempCharge * tempCharge) - tempCharge + 15) / 35);
        if (eletricCharge >= 30)
        {
            tempForScale.x = tempScale;
            tempForScale.y = tempScale;
            tempForScale.z = tempScale;

            transform.localScale = tempForScale;
            Debug.Log("tempForScale.x = " + tempForScale.x);
            tempForScale.x = (1 / tempScale);
            tempForScale.y = (1 / tempScale);
            tempForScale.z = (1 / tempScale);
            Debug.Log("tempForScale.x = " + tempForScale.x);
            
            if(distance == null)
                distance = grabObject.gameObject.transform.localPosition - transform.localPosition;
            grabObject.gameObject.transform.localScale = tempForScale;
            grabObject.gameObject.transform.localPosition = distance;
            tempForScale.x = tempScale;
            tempForScale.y = tempScale;
            tempForScale.z = tempScale;
        }
        else
        {
            // Do Nothing
            
        }
    }


    public void Charge()
    {
        eletricCharge = characterInfo.GetEletricCharge();
        eletricCharge += chargeSpeed;
        characterInfo.SetEletricCharge(eletricCharge);
        /*if (tempForScale.x > 3)
        {
            tempForScale.x = 3;
            tempForScale.y = 3;
            tempForScale.z = 3;
        }
        else
        {
            tempForScale.x += chargeRate;
            tempForScale.y += chargeRate;
            tempForScale.z += chargeRate;
        }
        transform.localScale = tempForScale;*/
    }

    private void Discharge(){
        eletricCharge = characterInfo.GetEletricCharge();
        eletricCharge -= Time.deltaTime * dischargeSpeed;
        characterInfo.SetEletricCharge(eletricCharge);
        if (eletricCharge > 100)
        {
            tempForScale.x -= dischargeRate;
            tempForScale.y -= dischargeRate;
            tempForScale.z -= dischargeRate;
        }
        else if (eletricCharge <= 100 && eletricCharge > 40)
        {
            tempForScale.x -= (dischargeRate / 2);
            tempForScale.y -= (dischargeRate / 2);
            tempForScale.z -= (dischargeRate / 2);
        }
        else if (eletricCharge <=  0 || (transform.localScale.x <= 0))
        {
            tempForScale.x = 0;
            tempForScale.y = 0;
            tempForScale.z = 0;
        }

        transform.localScale = tempForScale;
    }
}
