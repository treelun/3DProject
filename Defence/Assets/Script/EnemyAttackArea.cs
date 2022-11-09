using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : Enemy
{
    Animator anima;
    AudioSource audio;
    public bool isAttack = false;

    bool attackReady;
    float AttackSpeed = 2;
    float AttackDelay;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponentInParent<Animator>();
        audio = GetComponentInParent<AudioSource>();
    }
    private void FixedUpdate()
    {
        AttackDelay += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        

        attackReady = AttackSpeed < AttackDelay;
        if (other.transform.tag == "Player")
        {
            Debug.Log("target 공격");
            isAttack = true;
            if (attackReady)
            {
                anima.SetTrigger("Attrigger");
                audio.Play();
                AttackDelay = 0;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("target 공격범위 빠져나감");
            isAttack = false;
            target = other.transform;
        }
    }
}
