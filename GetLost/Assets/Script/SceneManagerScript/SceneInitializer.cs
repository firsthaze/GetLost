using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour {

    IEnumerator Start()
    {

        yield return new WaitForSeconds(3);

        SceneManager.ins.LoadOwnScene();
    }
}
