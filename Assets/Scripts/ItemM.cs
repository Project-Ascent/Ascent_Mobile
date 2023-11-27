using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemM : MonoBehaviour
{
    public static ItemM item;
    public bool beans;
    public bool airballoon;
    public bool goose;

    // Start is called before the first frame update
    void Start()
    {
        item = this;
        item.beans = false;
        item.airballoon = false;
        item.goose = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
