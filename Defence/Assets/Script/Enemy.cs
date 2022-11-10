using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Status
{
    public SphereCollider eye;
    public SphereCollider wanderArea;

    protected Transform target;
    protected bool isWalk;

    public bool isHit = false;

    public float Hitpoint;

    protected bool isDeath;
    protected bool isDestroy;

    private void FixedUpdate()
    {
        //�׾����� �ݶ��̴��� ��Ȱ��ȭ�� ������ ������
        if (isDeath)
        {
            eye.enabled = false;
            wanderArea.enabled = false;
        }
    }

    //enemy�� ĳ���͸� ���󰡰� �ϱ����� trigger����
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target = other.transform;
            isWalk = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target = other.transform;
            isWalk = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target = null;
            isWalk = false;
        }
    }
    //������ɶ��� ����
    public void ResetCharacter()
    {
        Hitpoint = startHp;
        isDeath = false;
    }

    //���������� �������� �޴� �޼���
    public void DamageCharacter(float damage)
    {
        Hitpoint = Hitpoint - damage;

        if (Hitpoint <= float.Epsilon) //float.Epsilon�� 0���� ū ���� ���� ����� ���� ��Ÿ��
        {
            isDeath = true;

        }
    }

    //Ȱ��ȭ�Ǹ� ������� ���� �ʱ�ȭ��
    private void OnEnable()
    {
        ResetCharacter();
    }


}
