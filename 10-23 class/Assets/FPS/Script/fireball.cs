using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{

    public float speed = 10.0f;
    public int damage = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharator player = other.GetComponent<PlayerCharator>();

        if (player != null)
        {
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }
}
