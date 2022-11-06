using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    GameObject enemy;
    public Transform target;
    float delta;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            CreateEnemy();
        }
        
    }

    void CreateEnemy()
    {
        enemy 
         = Instantiate(enemyPrefab, transform.position, transform.rotation);
    }


}
