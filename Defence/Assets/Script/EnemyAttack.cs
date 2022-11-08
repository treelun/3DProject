using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Enemy
{
    float targetHp;

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            targetHp = other.GetComponent<PlayerMove>().Hp;
            Debug.Log(targetHp);
        }
    }
}
