using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;

    public Transform target;
    float delta;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > 2f)
        {
            GameObject enemy = Instantiate(enemyPrefab[0], transform.position, transform.rotation);
            
            delta = 0;
        }
    }
}
