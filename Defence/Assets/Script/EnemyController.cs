using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Enemy
{
    public float velocity;
    public float accelaration;


    Animator anima;
    EnemyAttackArea area;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        area = GetComponentInChildren<EnemyAttackArea>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && !area.isAttack)
        {
            Debug.Log("¿òÁ÷¿©");
            MoveToTarget();
        }
        else if (target != null && area.isAttack)
        {
            StopMove();
        }
       
        anima.SetBool("isWalk", isWalk);
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
        transform.LookAt(target);
    }
    void StopMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0 * Time.deltaTime);
    }

}
