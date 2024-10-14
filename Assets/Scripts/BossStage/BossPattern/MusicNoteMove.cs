using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoteMove : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
    }
}
