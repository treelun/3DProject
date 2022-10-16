using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    GameObject particle;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.01f;
    
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
    private void Start()
    {
        particle = GameObject.Find("Particle");
    }

    private void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= this.ratio)
            {
                item = Instantiate(bombPrefab) as GameObject;
                particle.SetActive(false);
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
                particle.SetActive(true);
                particle.GetComponent<ParticleSystem>().Play();
            }
            
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<itemController>().dropSpeed = this.speed;
            particle.transform.position = new Vector3(x, 0, z);
            


        }
        
    }
}
