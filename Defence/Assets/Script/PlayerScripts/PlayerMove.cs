using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Status
{
    public float moveSpeed = 8f;
    public float rotateSpeed = 5f;
    public float jumpPower = 10f;
    Rigidbody rigid;
    Animator animator;
    Weapon Weapon;
    WeaponData weaponData;

    public CharaterData player;

    public AudioSource RightWalkAudio;
    public AudioSource LeftWalkAudio;
    public AudioSource dodge;

    Vector3 movement;

    float deltaX;
    float deltaZ;
    float AttackDelay;
    public float Hitpoint;

    bool JumpButton;
    bool AttackButton;

    bool isJump;
    bool isDodge;
    bool isAttackReady = true;
    public bool ishit;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        Weapon = GetComponentInChildren<Weapon>();
        weaponData = GetComponentInChildren<WeaponScriptAble>().weaponData;
    }

    private void FixedUpdate()
    {
        GetInput();
        playerMove();
        Jump();
        Dodge();
        Attack();

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

        movement = new Vector3(deltaX, 0f, deltaZ);

        movement = transform.TransformDirection(movement);
        if (!isAttackReady || isDodge || ishit)
        {
            movement = Vector3.zero;
        }
        

        transform.Rotate(0f, Input.GetAxis("Mouse X") * rotateSpeed, 0f, Space.World);
        if (deltaX != 0)
        {
            animator.SetFloat("Vertical", deltaX);
           
        }
        if (deltaZ != 0)
        {
            animator.SetFloat("Horizontal", deltaZ);
        }

        
        transform.position += movement * moveSpeed * Time.deltaTime;
  
    }
    void Jump()
    {
        if (JumpButton && !isJump)
        {
            Debug.Log("점프");
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
            animator.SetTrigger("JumpTrigger");
        }
    }
    void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isJump && movement != Vector3.zero)
        {
            animator.SetTrigger("dodgeleft");
            isDodge = true;
            dodge.Play();
            Invoke("DodgeOut", 0.5f);
        }
    }
    void DodgeOut()
    {
        isDodge = false;
    }

    public void Attack()
    {
        AttackDelay += Time.deltaTime;

        isAttackReady = weaponData.attackSpeed < AttackDelay;
        if (AttackButton && isAttackReady && !ishit)
        {
            animator.SetTrigger("AttackTrigger");
            Weapon.MeleeAttack();
            AttackDelay = 0;
            RightWalkAudio.Stop();
            LeftWalkAudio.Stop();
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
    void KillCharacter()
    {
        Destroy(gameObject);
    }
    public void ResetCharacter()
    {
        player.startingHp = startHp;
    }
    private void OnEnable()
    {
        ResetCharacter();
    }

    public void DamageCharacter(float damage)
    {

        player.startingHp -= damage;
        animator.SetTrigger("hitMotion");
        DamagedOut();
        if (player.startingHp <= float.Epsilon) //float.Epsilon은 0보다 큰 가장 작은 양수의 값을 나타냄
        {
            KillCharacter();
        }
        
    }
    IEnumerator playerHit()
    {
        yield return new WaitForSeconds(0.2f);
        ishit = true;

        yield return new WaitForSeconds(0.2f);
        ishit = false;
    }
    void DamagedOut()
    {
        StopCoroutine(playerHit());
        StartCoroutine(playerHit());
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isJump = false;
        }
    }

}
