using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    Animator anima;

    public BoxCollider AttackPoint;
    
    
    AudioSource audiosource;
    EnemyController enemyController;

    bool attackReady;
    float AttackSpeed = 5f;
    float AttackDelay;
    public bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponentInParent<Animator>();
        audiosource = GetComponent<AudioSource>();
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerStay(Collider other)
    {
        AttackDelay += Time.deltaTime;

        attackReady = AttackSpeed < AttackDelay;
        if (other.transform.tag == "Player")
        {
            anima.SetBool("isRun", false);
            anima.SetBool("isWalk", false);
            if (attackReady && !other.GetComponentInChildren<Weapon>().isHit && !enemyController.isDeath)
            {
                EnemyMeleeAttack();
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
        }
    }


    public void EnemyMeleeAttack()
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
        AttackPoint.enabled = true;
        

        yield return new WaitForSeconds(0.2f);
        AttackPoint.enabled = false;

    }
    IEnumerator StopWalk()
    {
        yield return new WaitForSeconds(0.1f);
        isAttack = true;

        yield return new WaitForSeconds(2f);
        isAttack = false;
    }
}
