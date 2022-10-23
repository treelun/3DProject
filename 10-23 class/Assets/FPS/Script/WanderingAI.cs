using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������� ������
//�����θ� ������ forward
//���տ� Ư�� ��ü�� �ִ°�? check
//Ư�� ������ �ִµ� ���̶�� attack
//���� ���, ���� �Ÿ���ŭ ��������� �ٸ��������� ��ȯ.
public class WanderingAI : MonoBehaviour
{
    public float wanderSpeed = 3f;
    public float obstacleRange = 5.0f;

    [SerializeField] GameObject fireballPrefab;
    GameObject _fireball;

    bool isALive = false;
    // Start is called before the first frame update
    void Start()
    {
        isALive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //����ִ°�
        if (isALive)
        {
            //������ �̵�
            transform.Translate(0, 0, wanderSpeed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray,0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                //hitObject�� ������Ʈ�� ������ �ֳ�?
                if (hitObject.GetComponent<PlayerCharator>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
            
        }

    }

    public void SetAlive(bool alive)
    {
        isALive = alive;
    }
}
