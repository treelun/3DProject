using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : CharaterData
{
    public float moveSpeed = 8f;
    public float rotateSpeed = 5f;
    public float jumpPower = 10f;
    CharacterController character;
    Animator animator;
    Weapon Weapon;
    Vector3 movement;

    float gravity = 9.8f;
    bool isAttack;
    private void Awake()
    {
        Weapon = GetComponentInChildren<Weapon>();
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
        playerMove();
        Attack();
    }

    void playerMove()
    {

        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        movement = new Vector3(deltaX, 0f, deltaZ) * moveSpeed;

        movement = transform.TransformDirection(movement);
        if (!isAttack)
        {
            Debug.Log("못움직임");
            movement = Vector3.zero;
        }
        if (Input.GetButton("Jump"))
        {
            Debug.Log("점프");
            movement.y = jumpPower;
        }
        transform.Rotate(0f, Input.GetAxis("Mouse X") * rotateSpeed, 0f, Space.World);
        if (deltaX != 0)
        {
            animator.SetFloat("Strafe", deltaX);
        }
        if (deltaZ != 0)
        {
            animator.SetFloat("Run", deltaZ);
        }

        movement.y -= gravity * Time.deltaTime;
    
        character.Move(movement * Time.deltaTime);
        

    }

    public void Attack()
    {

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("AttackTrigger");
            Cursor.lockState = CursorLockMode.Locked;
            Weapon.MeleeAttack();
            isAttack = true;
            
        }

        else if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack2Trigger");
            isAttack = true;
        }
       
    }

}
