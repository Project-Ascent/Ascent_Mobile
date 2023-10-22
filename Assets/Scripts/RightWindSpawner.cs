using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWindSpawner : MonoBehaviour
{
    public GameObject windPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWind", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWind()
    {
        Quaternion desiredRotation = Quaternion.Euler(180, 0, 180);
        Instantiate(windPrefab, transform.position, desiredRotation);
    }
}
