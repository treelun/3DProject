using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public bool isMove = false;
    GameObject Load;
    public GameObject spotLight;
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
            Move();
        }
       

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ClearZone")
        {
            spotLight.SetActive(true);
        }
    }

    void Move()
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
    }


}
