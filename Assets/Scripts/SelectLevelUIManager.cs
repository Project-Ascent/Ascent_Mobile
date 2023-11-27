using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        SceneManager.LoadScene("ClimbingLevel1_Mobile");
    }
    public void Level2()
    {
        SceneManager.LoadScene("ClimbingLevel2_Mobile");
    }
}
