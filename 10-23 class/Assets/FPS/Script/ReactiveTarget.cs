using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        StartCoroutine(Die());

        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        ZombieController zombiecon = GetComponent<ZombieController>();
        if (zombiecon != null)
        {
            zombiecon.SetAlive(false);
        }
    }

    IEnumerator Die()
    {
        if (TryGetComponent<NavMeshAgent>(out NavMeshAgent nav))
        {
            nav.enabled = false;
        }
        transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);

    }
}
