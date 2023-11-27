using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovementTutorial : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        // Vector3 playerPosition = player.transform.position;

        if (-40 < player.transform.position.x && player.transform.position.x < 40)
        {
            Vector3 moveVector = new Vector3((dir.x), (dir.y + 3.5f), 0.0f);
            this.transform.Translate(moveVector * cameraSpeed * Time.deltaTime);
        }
    }
}
