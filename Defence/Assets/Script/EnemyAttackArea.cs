using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : Enemy
{
    Animator anima;

    public BoxCollider AttackArea;
    
    AudioSource audiosource;

    bool attackReady;
    float AttackSpeed = 3f;
    float AttackDelay;
    public bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponentInParent<Animator>();
        audiosource = GetComponentInParent<AudioSource>();
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
            
            if (attackReady && !other.GetComponentInChildren<Weapon>().isHit && !isDeath)
            {
                MeleeAttack();
                anima.SetTrigger("Attrigger");
                AttackDelay = 0;
                audiosource.Play();
                isAttack = true;
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


    public void MeleeAttack()
    {
        StopCoroutine(Attack());
        StartCoroutine(Attack());
    }

    public void controlWalk()
    {
        StopCoroutine(StopWalk());
        StartCoroutine(StopWalk());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.2f);
        AttackArea.enabled = true;
        

        yield return new WaitForSeconds(0.2f);
        AttackArea.enabled = false;


    }
    IEnumerator StopWalk()
    {
        yield return new WaitForSeconds(0.1f);
        isAttack = true;

        yield return new WaitForSeconds(2f);
        isAttack = false;
    }
}
