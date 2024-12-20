using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSelected : MonoBehaviour
{
    public static ItemSelected IS;
    public bool checkDamaged;
    public string item = " ";
    private void Awake()
    {
        if (IS != null)
        {
        }
        IS = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BeansCheck()
    {
        ItemM.item.beans = true;
        ItemM.item.airballoon = false;
        ItemM.item.goose = false;
        print(ItemM.item.beans);
    }
    public void AirballoonCheck()
    {
        ItemM.item.beans = false;
        ItemM.item.airballoon = true;
        ItemM.item.goose = false;
        print(ItemM.item.airballoon);
    }

    public void GooseCheck()
    {
        ItemM.item.beans = false;
        ItemM.item.airballoon = false;
        ItemM.item.goose = true;
        print(ItemM.item.goose);
    }
    // Update is called once per frame
    void Update()
    {
        
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
        if (ItemM.item.beans)
        {
            item = "b";
            HPManager.Instance.IncreaseHP(1);
            ItemM.item.beans = false;
            if (SceneManager.GetActiveScene().name == "TutorialScene")
            {
                TutorialManager tm;
                tm = tm = GameObject.Find("TutorialManager").GetComponent<TutorialManager>();
                tm.missionCount += 1.0f;
                tm.checkMissionCount();
            }
        }
        else if (ItemM.item.airballoon)
        {
            item = "a";
            Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            rb.drag = 20;
            ItemM.item.airballoon = false;
            Invoke("FastFalling", 2f);

        }
        else if (ItemM.item.goose)
        {
            item = "g";
            checkDamaged = true;
            ItemM.item.goose = false;
            Invoke("GooseFinish", 5f);
        }
    }
}
