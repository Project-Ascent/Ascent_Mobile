using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchItem : MonoBehaviour
{
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Ãæµ¹");
    }*/
    public bool checkDamaged;
    public ItemM item;
    AudioSource itemSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "beans")
        {
            itemSound.Play();
            Destroy(collision.gameObject);
            item.beans = true;
            item.airballoon = false;
            item.goose = false;
            print(item.beans);
        }
        if (collision.tag == "airballoon")
        {
            itemSound.Play();
            Destroy(collision.gameObject);
            item.beans = false;
            item.airballoon = true;
            item.goose = false;

        }
        if (collision.tag == "goose")
        {
            itemSound.Play();
            Destroy(collision.gameObject);
            item.beans = false;
            item.airballoon = false;
            item.goose = true;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.Find("Player").GetComponent<ItemM>();
        item.beans = false;
        item.airballoon = false;
        item.goose = false;
        itemSound = GameObject.Find("ItemSound").GetComponent<AudioSource>();
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
        if (item.beans)
        {

            HPManager.Instance.IncreaseHP(1);
            item.beans = false;
        }
        else if (item.airballoon)
        {
            
            Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            rb.drag = 20;
            item.airballoon = false;
            Invoke("FastFalling", 2f);

        }
        else if (item.goose)
        {
            
            checkDamaged = true;
            item.goose = false;
            Invoke("GooseFinish", 5f);
        }
    }
}
