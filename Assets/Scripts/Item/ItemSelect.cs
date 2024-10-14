using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeansCheck()
    {
        if (!Item.item.beans)
        {
            Item.item.beans = true;
            Item.item.airballon = false;
            Item.item.goose = false;
            print(Item.item.beans);
        }
    }
    public void AirballonCheck()
    {
        if (!Item.item.airballon)
        {
            Item.item.beans = false;
            Item.item.airballon = true;
            Item.item.goose = false;
            print(Item.item.airballon);
        }
    }

    public void GooseCheck()
    {
        if (!Item.item.goose)
        {
            Item.item.beans = false;
            Item.item.airballon = false;
            Item.item.goose = true;
            print(Item.item.goose);
        }
    }
}
