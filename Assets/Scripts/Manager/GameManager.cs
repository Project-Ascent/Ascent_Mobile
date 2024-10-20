using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isTutorial = false;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



    public void LoadSceneWithName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public bool GetIsTutorial()
    {
        return isTutorial;
    }

    public void SetIsTutorial(bool isTutorial)
    {
        this.isTutorial = isTutorial;
    }

}
