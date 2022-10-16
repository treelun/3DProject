using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "target")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParticleSystem>().Play();
        }
    }

}
