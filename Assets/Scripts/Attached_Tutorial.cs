using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attached_Tutorial : MonoBehaviour
{
    GrapplingHook grappling;
    public DistanceJoint2D joint2D;
    TutorialManager tm;

    bool isTM1Hooked = false;
    bool isTM2Hooked = false;
    bool isTM3Hooked = false;
    bool isTM4Hooked = false;

    // Start is called before the first frame update
    void Start()
    {
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<DistanceJoint2D>();
        tm = GameObject.Find("TutorialManager").GetComponent<TutorialManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            joint2D.enabled = true;
            grappling.isRangeMax = true;
            grappling.isAttach = true;
        }

        if (collision.CompareTag("FinishObject"))
        {
            joint2D.enabled = true;
            grappling.isRangeMax = true;
            grappling.isAttach = true;
            Invoke("goToBossStage", 0.1f);
        }

        if (collision.CompareTag("TM1"))
        {
            joint2D.enabled = true;
            grappling.isRangeMax = true;
            grappling.isAttach = true;
            if (!isTM1Hooked)
            {
                tm.missionCount += 0.5f;
                isTM1Hooked = true;
                tm.checkMissionCount();
            }
        }

        if (collision.CompareTag("TM3"))
        {
            joint2D.enabled = true;
            grappling.isRangeMax = true;
            grappling.isAttach = true;
            if (!isTM3Hooked)
            {
                tm.missionCount += 0.5f;
                isTM3Hooked = true;
                tm.checkMissionCount();
            }
        }

        if (collision.CompareTag("TM2"))
        {
            joint2D.enabled = true;
            grappling.isRangeMax = true;
            grappling.isAttach = true;
            if (!isTM2Hooked)
            {
                tm.missionCount += 1f;
                isTM2Hooked = true;
                tm.checkMissionCount();
            }
        }

        if (collision.CompareTag("TM4"))
        {
            joint2D.enabled = true;
            grappling.isRangeMax = true;
            grappling.isAttach = true;
            if (!isTM4Hooked)
            {
                tm.missionCount += 1f;
                isTM4Hooked = true;
                tm.checkMissionCount();
                grappling.ResetHookState();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void goToBossStage()
    {
        SceneManager.LoadScene("BossStageScene");
    }
}
