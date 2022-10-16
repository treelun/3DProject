using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{

    private void Update()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "apple")
        {
            Debug.Log("»ç°ú");
            GameManager.instance.DropApple();
        }

    }
}
