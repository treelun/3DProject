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

        //ClampMagnitue 벡터의 길이를 구하는데 최솟값이 최대값을 설정해줌 최소값보다 작으면 최소값이되고 최대값보다 크면 최대값이됨
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        //Vector값의 앞을 바라보고
        movement = transform.TransformDirection(movement);
        //Move한다.
        myCharacterController.Move(movement);
    }
}
