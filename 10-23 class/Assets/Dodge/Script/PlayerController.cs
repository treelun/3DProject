using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*        if (Input.GetKey(KeyCode.UpArrow) == true)
                {
                    playerRigidbody.AddForce(0f, 0f, speed);
                }
                if (Input.GetKey(KeyCode.DownArrow) == true)
                {
                    playerRigidbody.AddForce(0f, 0f, -speed);
                }
                if (Input.GetKey(KeyCode.RightArrow) == true)
                {
                    playerRigidbody.AddForce(speed, 0f, 0f);
                }
                if (Input.GetKey(KeyCode.LeftArrow) == true)
                {
                    playerRigidbody.AddForce(-speed, 0f, 0f);
                }*/

        //수평 수직축 입력값을 감지 및 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        //Vec3 속도로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        //RigidBody에 할당
        playerRigidbody.velocity = newVelocity;

    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
