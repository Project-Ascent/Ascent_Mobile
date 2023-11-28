using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public void GoTutorialScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("current", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
