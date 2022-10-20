using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearZoneController : MonoBehaviour
{
    GameObject particle;
    GameObject particle1;
    GameObject light;
    public GameObject eye;
    public GameObject Charator;
    // Start is called before the first frame update
    void Start()
    {
        particle = GameObject.Find("ParticleSystem");
        particle1 = GameObject.Find("ParticleSystem1");
        light = GameObject.Find("Light");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Charator")
        {
            Debug.Log("Ä³¸¯ÅÍ ¿È");
            particle.GetComponent<ParticleSystem>().Play();
            particle1.GetComponent<ParticleSystem>().Play();
            light.SetActive(false);

            
        }
    }
}
