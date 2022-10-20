using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePosition : MonoBehaviour
{
    GameObject charator;

    float eyeposX;
    float eyeposZ;
    // Start is called before the first frame update
    void Start()
    {
        charator = GameObject.Find("Charator");
    }

    // Update is called once per frame
    void Update()
    {
        //카메라가 있을곳의 오브젝트 좌표는 캐릭터를 따라 다닐것으므로
        //캐릭터의 x와 z의 값을 대입해줌
        eyeposX = charator.transform.position.x;
        eyeposZ = charator.transform.position.z;

        transform.position = new Vector3(eyeposX, 40, eyeposZ);
    }
}
