using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{

    public int level;

    public void RetryStage()
    {
        if (level == 1)
        {
            
            SceneManager.LoadScene("ClimbingLevel1_Mobile");
        }

        if (level == 2)
        {
           
            SceneManager.LoadScene("ClimbingLevel2_Mobile");
        }
        if (level == 4)
        {
          
            SceneManager.LoadScene("BossStageScene");
        }
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
