using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCheckedInStage : MonoBehaviour
{
    public Sprite inven;
    public Sprite beans;
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


        }else
        {
            Image img = GetComponent<Image>();
            img.sprite = inven;
        }
    }
    
}
