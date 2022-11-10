using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Enemy
{
    Animator anima;
    public float velocity;
    public float accelaration;

    float delta;

   public EnemyAttackArea enemyAttackArea;
    private void Start()
    {
        anima = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null && !enemyAttackArea.isAttack && !isDeath)
        {
            MoveToTarget();
        }
        else if (target != null && enemyAttackArea.isAttack || isDeath)
        {
            StopMove();
        }

        //죽으면 2초뒤 오브젝트 파괴(나중에 오브젝트 풀링방식으로 바꿀예정)
        if (isDeath)
        {
            delta += Time.deltaTime;
            if (delta > 2f)
            {
                KillCharacter();
            }
        }
        anima.SetBool("isWalk", isWalk);
    }

    void MoveToTarget()
    {
        //점프했을때 플레이어의 위치로 걸어올라옴... 그래서 타겟의 y값은 본인의 y값으로
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x,transform.position.y,target.position.z), velocity * Time.deltaTime);
        //점프하면 rotation의 x값이 -90으로 바닥에 누워서 플레이어를 쳐다봄...수정하기위해 y값 만 본인의 값으로
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        
    }
    void StopMove()
    {
        //공격할때는 멈춰야 하므로 속도를 0으로
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0 * Time.deltaTime);
    }

    void KillCharacter()
    {
        Destroy(gameObject);
    }

}
