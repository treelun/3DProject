using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    private void Awake()
    {
        GeneratorNavMesh();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeneratorNavMesh();
    }
    void GeneratorNavMesh()
    {
        NavMeshSurface surfaces = gameObject.GetComponentInChildren<NavMeshSurface>();
        surfaces.BuildNavMesh();
    }
}
