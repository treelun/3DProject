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
        //죽었으면 콜라이더들 비활성화로 움직임 멈춰줌
        if (isDeath)
        {
            eye.enabled = false;
            wanderArea.enabled = false;
        }
    }

    //enemy가 캐릭터를 따라가게 하기위한 trigger값들
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
    //재생성될때의 값들
    public void ResetCharacter()
    {
        Hitpoint = startHp;
        isDeath = false;
    }

    //실질적으로 데미지를 받는 메서드
    public void DamageCharacter(float damage)
    {
        Hitpoint = Hitpoint - damage;

        if (Hitpoint <= float.Epsilon) //float.Epsilon은 0보다 큰 가장 작은 양수의 값을 나타냄
        {
            isDeath = true;

        }
    }

    //활성화되면 재생성시 값을 초기화함
    private void OnEnable()
    {
        ResetCharacter();
    }


}
