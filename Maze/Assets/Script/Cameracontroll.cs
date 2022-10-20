using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroll : MonoBehaviour
{
    GameObject eye;
    // Start is called before the first frame update
    void Start()
    {
        eye = GameObject.Find("eye");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = eye.transform.position;

    }
}
