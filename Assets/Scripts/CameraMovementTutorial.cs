using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovementTutorial : MonoBehaviour
{
    public float cameraSpeed = 4.7f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        Vector3 dir = player.transform.position - this.transform.position;
        if (player.transform.position.y < 40)
        {
            Vector3 moveVector = new Vector3(0.0f, (dir.y + 3.8f) * cameraSpeed * Time.deltaTime, 0.0f);
            this.transform.Translate(moveVector);
        }
    }
}
