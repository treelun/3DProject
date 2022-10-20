using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePosition : MonoBehaviour
{
    GameObject charator;

    float eyeposX;
    float eyeposZ;
    // Start is called before the first frame update
    void Start()
    {
        charator = GameObject.Find("Charator");
    }

    // Update is called once per frame
    void Update()
    {
        eyeposX = charator.transform.position.x;
        eyeposZ = charator.transform.position.z;

        transform.position = new Vector3(eyeposX, 40, eyeposZ);
    }
}
