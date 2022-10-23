using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//살아있으면 움직임
//앞으로만 움직임 forward
//내앞에 특정 물체가 있는가? check
//특정 물제가 있는데 적이라면 attack
//벽일 경우, 일정 거리만큼 가까워지면 다른방향으로 전환.
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
        //살아있는가
        if (isALive)
        {
            //앞으로 이동
            transform.Translate(0, 0, wanderSpeed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray,0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                //hitObject가 컴포넌트를 가지고 있나?
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
