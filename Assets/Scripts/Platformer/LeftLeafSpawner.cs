using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLeafSpawner : MonoBehaviour
{
    public GameObject leafPrefab;
    public Transform spawnPoint;
    public GameObject currentLeaf;
    public bool leafDestroyed;


    // Start is called before the first frame update
    void Start()
    {
        SpawnLeaf();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLeaf == null && !leafDestroyed)
        {
            leafDestroyed = true;
            Invoke("SpawnLeaf", 3f);
        }
    }
    void SpawnLeaf()
    {
        Quaternion desiredRotation = Quaternion.Euler(180, 0, 135);
        currentLeaf = Instantiate(leafPrefab, spawnPoint.position, desiredRotation);
        leafDestroyed = false;
    }
}
