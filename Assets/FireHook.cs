using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class FireHook : MonoBehaviour
{
    public GameObject prefab;
    public GameObject firePoint;


    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.position = firePoint.transform.position;
            clone.transform.rotation = firePoint.transform.rotation;
        }
    }
}
