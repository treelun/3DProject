using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    GameObject _zombie;
    // Update is called once per frame
    void Update()
    {
        if (_zombie == null)
        {
            float angle = Random.Range(0, 360);

            _zombie = Instantiate(zombiePrefab);
            _zombie.transform.position = new Vector3(20, 1.5f, -19);
            _zombie.transform.Rotate(0, angle, 0);
        }
    }
}
