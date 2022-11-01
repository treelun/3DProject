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
            Debug.Log("�� ����");
            Destroy(gameObject);
        }
    }

    void MoveToEnd()
    {
        //�������� ����̵�(������,�������� ������,�ӵ�)
        transform.position = Vector3.MoveTowards(gameObject.transform.position, endPoint.transform.position, 0.01f);
        //��� ��ǥ�� �ٶ󺸰���
        transform.LookAt(endPoint.transform);
    }

}
