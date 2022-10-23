using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    NavMeshAgent nav;

    GameObject player;

    bool isAlive = false;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            nav.SetDestination(player.transform.position);
        }

        
    }

    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }


}
