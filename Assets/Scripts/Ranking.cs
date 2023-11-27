using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ranking : MonoBehaviour
{
    float startTime;
    float finishTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FinishObject")
        {
            //Debug.Log("»ç´Ù¸®");
            finishTime = Time.time;
            PlayerPrefs.SetFloat("current", finishTime - startTime);
            print(PlayerPrefs.GetFloat("current"));
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
