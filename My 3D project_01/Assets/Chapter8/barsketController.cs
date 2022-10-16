using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barsketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "apple")
        {
            GameManager.instance.GetApple();
            audio.PlayOneShot(appleSE);
            float particleY = GetComponent<ParticleSystem>().shape.position.y;
            particleY = -3;
        }

        if (other.transform.tag == "bomb")
        {
            if (GameManager.instance.isDropApple == false)
            {
                GameManager.instance.Getbomb();
            }
           
            if (GameManager.instance.isDropApple == true)
            {
                GameManager.instance.Dropbomb();
                GameManager.instance.isDropApple = false;
            }
            
           
            
            audio.PlayOneShot(bombSE);
        }
        Destroy(other.gameObject);
    }
}
