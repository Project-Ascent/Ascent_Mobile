using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss_life : MonoBehaviour
{
    public float amount;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (amount == 2)
        {
            Destroy(GameObject.Find("BossLife_3"));
        }else if (amount == 1)
        {
            Destroy(GameObject.Find("BossLife_2"));
        }
        else if(amount <= 0)
        {
            Destroy(GameObject.Find("BossLife_1"));
            Invoke("ClearGame", 0f);
        }

        void ClearGame()
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
