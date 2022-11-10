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

        //������ 2�ʵ� ������Ʈ �ı�(���߿� ������Ʈ Ǯ��������� �ٲܿ���)
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
        //���������� �÷��̾��� ��ġ�� �ɾ�ö��... �׷��� Ÿ���� y���� ������ y������
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x,transform.position.y,target.position.z), velocity * Time.deltaTime);
        //�����ϸ� rotation�� x���� -90���� �ٴڿ� ������ �÷��̾ �Ĵٺ�...�����ϱ����� y�� �� ������ ������
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        
    }
    void StopMove()
    {
        //�����Ҷ��� ����� �ϹǷ� �ӵ��� 0����
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0 * Time.deltaTime);
    }

    void KillCharacter()
    {
        Destroy(gameObject);
    }

}
