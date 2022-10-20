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
                        //�������� ������(Ŭ���Ѱ�)�� Vector���� ��
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
            //ĳ���Ͱ� ���������� �����ϸ� ����Ʈ����Ʈ Ŵ
            spotLight.SetActive(true);

        }
        //����������
        if (collision.transform.tag == "Wall")
        {
            //���ӵ� 0���� ���� �ȱ׷��� ����� ���Ѿ��
            speed = 0;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //��� ���� ���������
        if (collision.transform.tag == "Wall")
        {
            //���ӵ� 0����, collisionenter�δ� ��������� �ȳѾ� �����Ƿ�
            //��� ��������� �� �Ѿ ������ ����� �Ѿ���� ���׹߻�
            //�ƿ� ����������� ���ӵ��� 0���� �ٲپ��־� �ȿ����̵��� ��
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
            //������������ �Ÿ��� 0.1���� ������ �̵�����
            if (Vector3.Distance(movepoint, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }
        }
        //�Ÿ��� Ŭ������ġ���� ĳ������ ��ġ�� ����
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
