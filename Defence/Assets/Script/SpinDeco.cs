using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDeco : MonoBehaviour
{
    public float rotateSpeed = 250f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }
}
