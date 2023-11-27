using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attached : MonoBehaviour
{
    GrapplingHook grappling;
    public DistanceJoint2D joint2D;
    // Start is called before the first frame update
    void Start()
    {
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<DistanceJoint2D>(); 
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
        }

        if (collision.CompareTag("TM2"))
        {
            joint2D.enabled = true;
            grappling.isRangeMax = true;
            grappling.isAttach = true;
        }

        if (collision.CompareTag("TM4"))
        {

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
