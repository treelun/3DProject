using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float rotateSpeed = 5f;
    CharacterController character;
    Animator animator;

    float gravity = -9.8f;
    bool isRun = false;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void FixedUpdate()
    {
        playerMove();

    }

    void playerMove()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(deltaX, 0f, deltaZ) * moveSpeed;
        movement.y = gravity;

        movement = transform.TransformDirection(movement);
        character.Move(movement * Time.deltaTime);
        transform.Rotate(0f, Input.GetAxis("Mouse X") * rotateSpeed, 0f, Space.World);
        if (deltaX != 0)
        {
            Debug.Log("deltaX : " + deltaX);
            animator.SetFloat("Strafe", deltaX);
        }
        if (deltaZ != 0)
        {
            Debug.Log("deltaX : " + deltaZ);
            animator.SetFloat("Run", deltaZ);
        }

    }

}
