using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Enemy
{
    public float velocity;
    public float accelaration;
    Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            MoveToTarget();
            //anima.SetBool("isWalk", isWalk);
        }
        anima.SetBool("isWalk", isWalk);





    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
        transform.LookAt(target);
    }



}
