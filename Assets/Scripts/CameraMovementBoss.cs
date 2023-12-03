using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraMovementBoss : MonoBehaviour
{
    public float cameraSpeed = 4.7f;
    public bool death = false;
    public GameObject player;

    void Update()
    {

        Vector3 dir = player.transform.position - this.transform.position;
        if (!death && player.transform.position.y < 20)
        {
            Vector3 moveVector = new Vector3(0.0f, (dir.y + 3.5f) * cameraSpeed * Time.deltaTime, 0.0f);
            // 박준범 폰 S23 : 3.2f
            // 최민규 폰 S10 5G : 3.5f
            this.transform.Translate(moveVector);
        }
    }
}
