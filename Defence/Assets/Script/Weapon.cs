using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponData weapon;
    AudioSource audiosouce;

    public BoxCollider AttackArea;
    public bool isHit;
    float delta;
    private void Start()
    {
        weapon = GetComponent<WeaponScriptAble>().weaponData;
        audiosouce = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            Animator enemyani = other.GetComponent<Animator>();
            enemy.DamageCharacter(weapon.damage);
            enemyani.SetTrigger("hitMotion");
            if (enemy.Hitpoint <= float.Epsilon) //float.Epsilon은 0보다 큰 가장 작은 양수의 값을 나타냄
            {
                enemyani.SetTrigger("death");
            }
        }

    }

    public void MeleeAttack()
    {
        StopCoroutine(Attack());
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.2f);
        AttackArea.enabled = true;
        isHit = true;
        audiosouce.Play();

        yield return new WaitForSeconds(0.2f);
        AttackArea.enabled = false;
        isHit = false;
        audiosouce.Stop();

    }

}
