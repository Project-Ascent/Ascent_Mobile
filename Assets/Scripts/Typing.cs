using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Typing : MonoBehaviour
{
    public TMP_Text text;
    public string vic;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        vic = "VICTORY";
        StartCoroutine(Type(vic));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Type(string talk)
    {
        text.text = null;
        for(int i=0; i < talk.Length; i++)
        {
            text.text += talk[i];
            yield return new WaitForSeconds(speed);
        }
    }
}
