using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWindSpawner : MonoBehaviour
{
    public GameObject windPrefab;
    void Start()
    {
        InvokeRepeating("SpawnWind", 0f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWind()
    {
        Instantiate(windPrefab, transform.position, transform.rotation);
    }
}
