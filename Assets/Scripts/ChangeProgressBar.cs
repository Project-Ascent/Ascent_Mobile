using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeProgressBar : MonoBehaviour
{
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float player = GameObject.Find("Player").transform.position.y;
        if (player >= 0)
        {
            float ratio = player / 100;
            img.fillAmount = ratio;
        }
        
    }
}
