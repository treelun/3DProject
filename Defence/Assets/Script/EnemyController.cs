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
            Debug.Log("������");
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

}
