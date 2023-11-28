using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TutorialManager : MonoBehaviour
{
    public float missionCount = 0.0f;
    [SerializeField] private GameObject goodJobText;
    [SerializeField] private GameObject[] tm1TextObjects;
    [SerializeField] private GameObject[] tm2TextObjects;
    [SerializeField] private GameObject[] tm3TextObjects;
    [SerializeField] private GameObject[] tm4TextObjects;

    [SerializeField] public GameObject tm1TextBoss;
    [SerializeField] public GameObject tm2TextBoss;


    // Start is called before the first frame update
    void Start()
    {
        goodJobText.SetActive(false);
        init();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void init()
    {
        tm1TextObjects = GameObject.FindGameObjectsWithTag("TM1Text");
        tm2TextObjects = GameObject.FindGameObjectsWithTag("TM2Text");
        tm3TextObjects = GameObject.FindGameObjectsWithTag("TM3Text");
        tm4TextObjects = GameObject.FindGameObjectsWithTag("TM4Text");


        tm1TextBoss = GameObject.Find("BossText1");
        tm2TextBoss = GameObject.Find("BossText2");
        tm2TextBoss.SetActive(false);
        
        foreach (GameObject tm2TextObject in tm2TextObjects)
        {
            tm2TextObject.SetActive(false);
        }
        foreach (GameObject tm3TextObject in tm3TextObjects)
        {
            tm3TextObject.SetActive(false);
        }
        foreach (GameObject tm4TextObject in tm4TextObjects)
        {
            tm4TextObject.SetActive(false);
        }
    }


    public void checkMissionCount()
    {
        if (missionCount == 1.0f) ClearMission1();
        if (missionCount == 2.0f) ClearMission2();
        if (missionCount == 3.0f) ClearMission3();
        if (missionCount == 4.0f) ClearMission4();
    }
    void ClearMission1()
    {
        Debug.Log("Mission 1 Clear");
        goodJobText.SetActive(true);

        foreach (GameObject tm1TextObject in tm1TextObjects)
        {
            tm1TextObject.SetActive(false);
        }
        foreach (GameObject tm2TextObject in tm2TextObjects)
        {
            Debug.Log("Mission 2 Open");
            tm2TextObject.SetActive(true);
        }
        Invoke("SetTextGone", 2f);
    }

    void ClearMission2()
    {
        goodJobText.SetActive(true);
        foreach (GameObject tm2TextObject in tm2TextObjects)
        {
            tm2TextObject.SetActive(false);
        }
        foreach (GameObject tm3TextObject in tm3TextObjects)
        {
            tm3TextObject.SetActive(true);
        }
        Invoke("SetTextGone", 2f);
    }

    void ClearMission3()
    {
        goodJobText.SetActive(true);
        foreach (GameObject tm3TextObject in tm3TextObjects)
        {
            tm3TextObject.SetActive(false);
        }
        foreach (GameObject tm4TextObject in tm4TextObjects)
        {
            tm4TextObject.SetActive(true);
        }
        Invoke("SetTextGone", 2f);
    }

    void ClearMission4()
    {
        goodJobText.SetActive(true);
        foreach (GameObject tm4TextObject in tm4TextObjects)
        {
            tm4TextObject.SetActive(false);
        }
        // Player의 Transform 컴포넌트를 가져오기
        Transform playerTransform = GameObject.Find("Player").transform;

        // 새로운 위치로 Player 이동
        playerTransform.position = new Vector3(-10f, -3.18f, 0f);
        Invoke("SetTextGone", 2f);
    }

    void SetTextGone()
    {
        goodJobText.SetActive(false);
    }
}
