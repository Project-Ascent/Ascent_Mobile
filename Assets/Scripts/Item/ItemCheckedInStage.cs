using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCheckedInStage : MonoBehaviour
{
    public Sprite inven;
    public Sprite beans;
    public Sprite airballon;
    public Sprite goose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Item.item.beans)
        {
            Image img = GetComponent<Image>();
            img.sprite = beans;


        }
        else if (Item.item.airballon)
        {
            Image img = GetComponent<Image>();
            img.sprite = airballon;


        }
        else if (Item.item.goose)
        {
            Image img = GetComponent<Image>();
            img.sprite = goose;


        }
        else
        {
            Image img = GetComponent<Image>();
            img.sprite = inven;
        }
    }
    
}
