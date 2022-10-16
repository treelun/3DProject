using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject cube = Instantiate(cubePrefab);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayDir = ray.direction;

            cube.GetComponent<Rigidbody>().AddForce(rayDir.normalized * 2000);
            

        }

    }
}
