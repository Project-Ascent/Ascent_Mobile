using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class boss_life : MonoBehaviour
{
    public float amount;
    public Image life3, life2, life1;
    public bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlay && amount == 3)
        {
            if (!life3.enabled)
                life3.enabled = true;
        }
        if (amount == 2)
        {
            isPlay = true;
            life3.enabled = false;
            if (!life2.enabled)
                life2.enabled = true;

        }
        else if (amount == 1)
        {
            life3.enabled = false;
            life2.enabled = false;
            //life1.enabled = true;
        }
        else if (amount <= 0)
        {
            life3.enabled = false;
            life2.enabled = false;
            life1.enabled = false;
            

            SceneManager.LoadScene("WinScene");
        }

    }
}
