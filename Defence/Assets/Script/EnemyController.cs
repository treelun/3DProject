using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject endPoint;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = GameObject.Find("EndPoint");
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        nav.destination = endPoint.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.transform.tag == "EndPoint")
        {
            Debug.Log("끝 도착");
            Destroy(gameObject);
        }
    }

    void MoveToEnd()
    {
        //목적지로 등속이동(포지션,목적지의 포지션,속도)
        transform.position = Vector3.MoveTowards(gameObject.transform.position, endPoint.transform.position, 0.01f);
        //계속 목표를 바라보게함
        transform.LookAt(endPoint.transform);
    }

}
