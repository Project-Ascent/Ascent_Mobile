using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    GameObject player;
    GameObject hook;
    GrapplingHook gh;
    PlayerMove ps;

    [SerializeField] private GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ps = player.GetComponent<PlayerMove>();
    }

    public void LeftUp()
    {
        ps.inputLeft = false;
        // gh.isHookFired = false;
    }

    public void LeftDown()
    {
        ps.inputLeft = true;
        // gh.isHookFired = true;

    }

    public void RightUp()
    {
        ps.inputRight = false;
        // gh.isHookFired = false;
    }

    public void RightDown()
    {
        ps.inputRight = true;
        // gh.isHookFired = true;
    }

    public void Pause()
    {
        Time.timeScale = 0; 
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LobbyScene");
        Destroy(this);
    }

    // Only used in TutorialScene 
    public void SkipTutorial()
    {
        SceneManager.LoadScene("SelectLevelScene");
        Destroy(this);
    }
}
