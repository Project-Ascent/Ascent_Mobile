using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 4.7f;
    public bool death = false;
    public GameObject player;
    public float currentLevel;

    void Update()
    {
       
        Vector3 dir = player.transform.position - this.transform.position;
        if (dir.y + Camera.main.orthographicSize < -1)
        {
            // death = true;
            Invoke("RestartGame", 0.1f);
            
        }
        if (!death && player.transform.position.y < 92)
        {
            Vector3 moveVector = new Vector3(0.0f, (dir.y + 3.8f) * cameraSpeed * Time.deltaTime, 0.0f);
            this.transform.Translate(moveVector);
        }
    }

    void RestartGame()
    {
        if (currentLevel == 1)
        {
            SceneManager.LoadScene("GameOverScene1");
        }
        if (currentLevel == 2)
        {
            SceneManager.LoadScene("GameOverScene1");
        }
        if (currentLevel == 3)
        {
            SceneManager.LoadScene("GameOverScene3");
        }
        if (currentLevel == 4)
        {
            SceneManager.LoadScene("GameOverSceneBoss");
        }
    }
}
