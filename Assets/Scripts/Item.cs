using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static Item item;
    public bool beans;
    public bool airballon;
    public bool goose;
    

   /* private void Awake()
    {
        if (item != null)
        {
            Destroy(gameObject);
            return;
        }
        item = this;
        DontDestroyOnLoad(gameObject);
    }*/
    // Start is called before the first frame update
    void Start()
    {
        item = this;
        item.beans = false;
        item.airballon = false;
        item.goose = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
