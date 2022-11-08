using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponData weapon;


    public BoxCollider AttackArea;
    private void Start()
    {
        weapon = GetComponent<ScriptAble>().weaponData;
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Debug.Log("Àû Å¸°Ý : " + weapon.damage);

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

        yield return new WaitForSeconds(0.2f);
        AttackArea.enabled = false;

    }
}
