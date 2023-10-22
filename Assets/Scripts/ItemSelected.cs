using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelected : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            UseItem();
        }
    }
    public void BeansCheck()
    {
        if (!Item.item.beans)
        {
            Item.item.beans = true;
        }
    }
    public void UseItem()
    {
        if (Item.item.beans)
        {
            
          
            Life life = GameObject.Find("Player").GetComponent<Life>();
            if (life.amount < 3)
            {
                Item.item.beans = false;
                life.amount++;
            }
        }
    }
}
