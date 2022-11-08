using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharaterData
{
    protected Transform target;
    protected bool isWalk;

    public bool isHit = false;
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

}
