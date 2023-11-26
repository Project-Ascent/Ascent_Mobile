using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    GameObject player;
    GameObject hook;
    GrapplingHook gh;
    PlayerMove ps;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ps = player.GetComponent<PlayerMove>();
        hook = GameObject.FindGameObjectWithTag("PlayerHook");
        gh = hook.GetComponent<GrapplingHook>();
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

}
