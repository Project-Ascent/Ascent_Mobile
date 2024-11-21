using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ThornDetect : MonoBehaviour
{
    public static ThornDetect td;
    public float damage;
    AudioSource damagedSound;

    void Start()
    {
        // 사운드매니저가 필요할거 같은데 따로
        damagedSound = GameObject.Find("Thornsound").GetComponent<AudioSource>();
    }

}
