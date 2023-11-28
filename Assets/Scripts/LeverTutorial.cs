using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverTutorial : MonoBehaviour
{
    private Animator animator;
    AudioSource leverSound;

    private bool lever_activate = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        leverSound = GameObject.Find("lever_sound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (lever_activate) return;
            Debug.Log("lever_activate");

            lever_activate = true;
            leverSound.Play();
            animator.Play("lever_on");
            Invoke("MoveScene", 2.0f);
        }
    }

    void MoveScene()
    {
        SceneManager.LoadScene("SelectLevelScene");
    }
}
