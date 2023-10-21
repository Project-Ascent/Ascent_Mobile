using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public bool death = false;
    public GameObject player;

    void Update()
    {
       
        Vector3 dir = player.transform.position - this.transform.position;
        if (dir.y + Camera.main.orthographicSize <0)
        {
            death = true;
            Invoke("RestartGame", 0.1f);
            
        }
        if (!death)
        {
            Vector3 moveVector = new Vector3(0.0f, (dir.y + 3.8f) * cameraSpeed * Time.deltaTime, 0.0f);
            
            this.transform.Translate(moveVector);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
