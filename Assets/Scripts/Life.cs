using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
    public float amount;
    public Image life3;
    public Image life2;
    public Image life1;
    public bool isPlay = false;
    public bool isDamaged = false;
    public float currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay&&amount==3)
        {
            if (!life3.enabled)
                life3.enabled = true;
        }
        if (amount == 2)
        {
            isPlay = true;
            life3.enabled = false;
            if(!life2.enabled)
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
            Invoke("RestartGame", 0f);
        }
    }

    void RestartGame()
    {
        if (currentLevel == 1)
        {
            SceneManager.LoadScene("GameOverScene1");
        }
        if (currentLevel == 2)
        {
            SceneManager.LoadScene("GameOverScene1");
        }
        if (currentLevel == 3)
        {
            SceneManager.LoadScene("GameOverScene3");
        }
        if (currentLevel == 4)
        {
            SceneManager.LoadScene("GameOverSceneBoss");
        }
    }
}
