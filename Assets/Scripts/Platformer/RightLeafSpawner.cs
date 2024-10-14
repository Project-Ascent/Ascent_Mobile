using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSpawner : MonoBehaviour
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
        Quaternion desiredRotation = Quaternion.Euler(0, 0, 315);
        currentLeaf = Instantiate(leafPrefab, spawnPoint.position, desiredRotation);
        leafDestroyed = false;
    }
}
