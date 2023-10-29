using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelected : MonoBehaviour
{
    public static ItemSelected IS;
    public Life life;
    public bool checkDamaged;

    private void Awake()
    {
        if (IS != null)
        {
            Destroy(gameObject);
            return;
        }
        IS = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            UseItem();
        }
    }
    void FastFalling()
    {
        Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb.drag = 0.5f;
    }
    void GooseFinish()
    {
        
            
     
        
        checkDamaged = false;
        Item.item.goose = false;
        


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
        else if (Item.item.airballon)
        {
            Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            rb.drag = 20;
            Item.item.airballon = false;
            Invoke("FastFalling", 2f);

        }
        else if (Item.item.goose)
        {
            checkDamaged = true;
            Invoke("GooseFinish", 5f);
            
            
            


        }
    }
}
