using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelected : MonoBehaviour
{
    public static ItemSelected IS;
    public Life life;
    public bool checkDamaged;
    public string item = " ";
    private void Awake()
    {
        if (IS != null)
        {
            print("Break");
            //Destroy(gameObject);

        }
        IS = this;
        print("Good");
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BeansCheck()
    {

        Item.item.beans = true;
        Item.item.airballon = false;
        Item.item.goose = false;
        print(Item.item.beans);
    }
    public void AirballonCheck()
    {
        Item.item.beans = false;
        Item.item.airballon = true;
        Item.item.goose = false;
        print(Item.item.airballon);
    }

    public void GooseCheck()
    {
        Item.item.beans = false;
        Item.item.airballon = false;
        Item.item.goose = true;
        print(Item.item.goose);
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
    }
    public void UseItem()
    {
        if (Item.item.beans)
        {

            item = "b";
            Life life = GameObject.Find("Player").GetComponent<Life>();
            if (life.amount < 3)
            {
                Item.item.beans = false;
                life.amount++;
            }
        }
        else if (Item.item.airballon)
        {
            item = "a";
            Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            rb.drag = 20;
            Item.item.airballon = false;
            Invoke("FastFalling", 2f);

        }
        else if (Item.item.goose)
        {
            item = "g";
            checkDamaged = true;
            Item.item.goose = false;
            Invoke("GooseFinish", 5f);
        }
    }
}
