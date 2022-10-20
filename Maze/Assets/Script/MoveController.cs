using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public bool isMove = false;
    GameObject Load;
    public GameObject spotLight;
    float speed = 0;
    Vector3 movepoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Load = GameObject.Find("Load");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.moveCount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycast;
                speed = 20f;
                if (Physics.Raycast(ray, out raycast))
                {
                    string objectName = raycast.collider.gameObject.tag;
                    Debug.Log(objectName);
                

                    if (objectName == "Load" || objectName == "ClearZone")
                    {
                        //레이저가 맞은곳(클릭한곳)의 Vector값을 줌
                        SetmovePoint(raycast.point);
                    
                    }
               
               
                }

                if (isMove == true)
                {
                    GameManager.instance.moveCount--;
                    
                }
            }
            if (isMove == true)
            {
                move();
            }
        
           

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ClearZone")
        {
            //캐릭터가 도착지점에 도착하면 스포트라이트 킴
            spotLight.SetActive(true);

        }
        //벽에닿으면
        if (collision.transform.tag == "Wall")
        {
            //가속도 0으로 변경 안그러면 비비기로 벽넘어가짐
            speed = 0;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //계속 벽에 닿아있으면
        if (collision.transform.tag == "Wall")
        {
            //가속도 0으로, collisionenter로는 닿았을때만 안넘어 가지므로
            //계속 닿아있을때 벽 넘어를 누르면 비비기로 넘어가지는 버그발생
            //아예 닿아있을때도 가속도를 0으로 바꾸어주어 안움직이도록 함
            speed = 0;
        }
    }
    void SetmovePoint(Vector3 _movePoint)
    {
        movepoint = _movePoint;
        
        isMove = true;

    }
    void move()
    {
        if (isMove == true)
        {
            //목적지까지의 거리가 0.1보다 작으면 이동중지
            if (Vector3.Distance(movepoint, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }
        }
        //거리는 클릭한위치에서 캐릭터의 위치를 뺀값
        var dir = movepoint - transform.position;
        
        transform.position += dir.normalized * Time.deltaTime * speed;
    }

/*    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycast;

            if (Physics.Raycast(ray, out raycast, Mathf.Infinity))
            {
                string objectName = raycast.collider.gameObject.tag;
                Debug.Log(objectName);
                if (objectName == "Load" || objectName == "ClearZone")
                {
                    float x = Mathf.RoundToInt(raycast.point.x);
                    float z = Mathf.RoundToInt(raycast.point.z);

                    transform.position = new Vector3(x, 2, z);

                    isMove = true;
                }
                
            }

            if (isMove == true)
            {
                GameManager.instance.moveCount--;
                isMove = false;
            }
        }
    }*/


}
