using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwanerController : MonoBehaviour
{
    [SerializeField] GameObject bulletPerfab;
    float timeAfterSpawn;
    public float spawncountMax = 3f;
    public float spawncountMin = 0.5f;

    float spawnRate;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0;
        spawnRate = Random.Range(spawncountMin, spawncountMax);
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;
            GameObject bullet = Instantiate(bulletPerfab, transform.position,transform.rotation);

            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawncountMin, spawncountMax);
        }

    }
    
}
