using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRanking : MonoBehaviour
{
    float climbingTime;
    float startTime;
    float finishTime;

    // Start is called before the first frame update
    void Start()
    {
        climbingTime = PlayerPrefs.GetFloat("current");
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        boss_life life = GameObject.Find("boss").GetComponent<boss_life>();
        if (life.amount == 0)
        {
            finishTime = Time.time;
            PlayerPrefs.SetFloat("current", climbingTime + finishTime - startTime);
            print(PlayerPrefs.GetFloat("current"));
        }
    }
}