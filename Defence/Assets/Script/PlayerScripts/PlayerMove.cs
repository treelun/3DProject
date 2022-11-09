using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : CharaterData
{
    public float moveSpeed = 8f;
    public float rotateSpeed = 5f;
    public float jumpPower = 10f;
    Rigidbody rigid;
    Animator animator;
    Weapon Weapon;
    WeaponData weaponData;
    Vector3 movement;

    float gravity = 9.8f;

    float deltaX;
    float deltaZ;
    float AttackDelay;

    bool isAttackReady = true;
    bool JumpButton;
    bool AttackButton;
    bool isJump;
    private void Awake()
    {
        Weapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        weaponData = GetComponentInChildren<ScriptAble>().weaponData;


    }

    private void FixedUpdate()
    {
        GetInput();
            playerMove();
            Jump();
      
            Attack();
        SpinAttack();


    }
    void GetInput()
    {
        JumpButton = Input.GetButtonDown("Jump");
        deltaX = Input.GetAxis("Horizontal");
        deltaZ = Input.GetAxis("Vertical");
        AttackButton = Input.GetMouseButtonDown(0);
    }

    void playerMove()
    {

        movement = new Vector3(deltaX, 0f, deltaZ).normalized;

        movement = transform.TransformDirection(movement);
        if (!isAttackReady)
        {
            movement = Vector3.zero;
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

        //rigid.AddForce(Vector3.down * gravity * Time.deltaTime);
        transform.position += movement * moveSpeed * Time.deltaTime;
        //character.Move(movement * Time.deltaTime);
        

    }
    void Jump()
    {
        if (JumpButton && !isJump)
        {
            Debug.Log("Á¡ÇÁ");
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
            animator.SetTrigger("JumpTrigger");
        }
    }

    public void Attack()
    {
        AttackDelay += Time.deltaTime;

        isAttackReady = weaponData.attackSpeed < AttackDelay;
        if (AttackButton && isAttackReady)
        {
            animator.SetTrigger("AttackTrigger");
            //Cursor.lockState = CursorLockMode.Locked;
            Weapon.MeleeAttack();
            AttackDelay = 0;

        }

       
    }
    void SpinAttack()
    {
        AttackDelay += Time.deltaTime;
        isAttackReady = weaponData.attackSpeed + 2 < AttackDelay;

        if (Input.GetMouseButtonDown(1) && isAttackReady)
        {
            animator.SetTrigger("Attack2Trigger");
            Weapon.MeleeAttack();
            AttackDelay = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("¶¥¿¡´êÀ½");
            isJump = false;
        }
    }

}
