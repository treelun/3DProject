using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerret : MonoBehaviour
{
    [SerializeField] GameObject terretPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreatePrefab();

        }
    }

    void CreatePrefab()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,100f))
        {
            /*            float x = hit.point.x;
                        float z = hit.point.z;*/

            Vector3 hitPos = hit.point;
            hitPos.y = 0.3f;
            GameObject terret = Instantiate(terretPrefab);
            terret.transform.position = hitPos;
        }
        
    }

}
