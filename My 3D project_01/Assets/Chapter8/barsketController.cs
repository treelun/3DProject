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
            audio.PlayOneShot(appleSE);
            Debug.Log("apple擠學營儅");
        }

        if (other.transform.tag == "bomb")
        {
            audio.PlayOneShot(bombSE);
            Debug.Log("bomb擠學營儅");
        }
        Destroy(other.gameObject);
    }
}
