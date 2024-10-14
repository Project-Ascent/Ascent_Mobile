using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCheckedInStage1 : MonoBehaviour
{
    ItemM item;
    public Sprite inven;
    public Sprite beans;
    public Sprite airballon;
    public Sprite goose;
    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.Find("Player").GetComponent<ItemM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (item.beans)
        {
            Image img = GetComponent<Image>();
            img.sprite = beans;


        }
        else if (item.airballoon)
        {
            Image img = GetComponent<Image>();
            img.sprite = airballon;


        }
        else if (item.goose)
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
