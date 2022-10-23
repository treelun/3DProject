using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSinput : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -9.8f;

    CharacterController myCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //ClampMagnitue ������ ���̸� ���ϴµ� �ּڰ��� �ִ밪�� �������� �ּҰ����� ������ �ּҰ��̵ǰ� �ִ밪���� ũ�� �ִ밪�̵�
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        //Vector���� ���� �ٶ󺸰�
        movement = transform.TransformDirection(movement);
        //Move�Ѵ�.
        myCharacterController.Move(movement);
    }
}
