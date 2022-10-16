using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    int bamcount = 0;
    int cubecount = 0;
    GameObject particle;
    GameObject particle2;
    private void Start()
    {
        particle = GameObject.Find("particle");
        particle2 = GameObject.Find("particle2");

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "bamsongi")
        {
            bamcount++;
            Debug.Log(bamcount);
        }
        if (collision.transform.tag == "cube")
        {
            cubecount++;
            Debug.Log(cubecount);
        }
        if (bamcount == 3 && cubecount == 2)
        {
            particle.GetComponent<ParticleSystem>().Play();
            particle2.GetComponent<ParticleSystem>().Play();
        }
    }

}
