using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    float missionCount = 0.0f;
    [SerializeField] private GameObject goodJobText;
    // Start is called before the first frame update
    void Start()
    {
        goodJobText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            Debug.Log("장애물");
        }

        if (collision.CompareTag("FinishObject"))
        {
            Debug.Log("사다리");
        }
    }

    void ClearMisson1()
    {
        if (missionCount == 1.0f)
        {
            goodJobText.SetActive(true);
            Invoke("SetTextGone", 2f);
        }
    }

    void ClearMisson2()
    {

    }

    void ClearMisson3()
    {

    }

    void ClearMisson4()
    {

    }

    void SetTextGone()
    {
        goodJobText.SetActive(false);
    }
}
