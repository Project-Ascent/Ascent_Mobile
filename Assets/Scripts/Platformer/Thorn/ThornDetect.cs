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
        // ����Ŵ����� �ʿ��Ұ� ������ ����
        damagedSound = GameObject.Find("Thornsound").GetComponent<AudioSource>();
    }

}
