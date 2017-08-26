using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesLoader : MonoBehaviour
{
    public enum Scenes
    {
        Start = 0,
        Test1,
        Test2,
        Test3
    }

    public static ScenesLoader ins;

    public Scenes own;

    void Awake()
    {
        if (ins == null)
        {

            ins = this;
            GameObject.DontDestroyOnLoad(gameObject);
            SceneManager.ins.OwnSecne = (int)this.own;

        }
        else if (ins != this)
        {

            Destroy(gameObject);
        }
    }

    public void LoadLevel(Scenes target)
    {

        SceneManager.ins.LoadScene((int)target);
    }
}
