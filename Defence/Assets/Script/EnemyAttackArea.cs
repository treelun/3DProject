using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : Enemy
{
    Animator anima;
    public bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anima.SetBool("isAttack", isAttack);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("target ����");
            isAttack = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("target ���ݹ��� ��������");
            isAttack = false;
            target = other.transform;
        }
    }
}
