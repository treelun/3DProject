using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 8f;
    float gavitiy = -9.8f;

    float rotateSpeed = 3;
    float playerRotateY;
    CharacterController charactercon;
    // Start is called before the first frame update
    void Start()
    {
        charactercon = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float posX = Input.GetAxis("Horizontal") * speed;
        float posZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(posX, 0, posZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gavitiy;

        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        charactercon.Move(movement);
        playerRotateY = Input.GetAxis("Mouse X") * rotateSpeed;
        transform.Rotate(0, playerRotateY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            Die();
        }
    }
    void Die()
    {
        gameObject.SetActive(false);

        GameManager manager = FindObjectOfType<GameManager>();

        manager.EndGame();

    }
}
