using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    public int level;

    public void SceneChange()
    {
        if (ItemSelected.IS.item == "b")
            Item.item.beans = true;
        else if (ItemSelected.IS.item == "a")
            Item.item.airballon = true;
        else if (ItemSelected.IS.item == "g")
            Item.item.goose = true;
        if (level == 1)
        {
            
            SceneManager.LoadScene("ClimbingLevel1");
        }

        if (level == 2)
        {
           
            SceneManager.LoadScene("ClimbingLevel2");
        }
        if (level == 3)
        {
            SceneManager.LoadScene("ClimbingLevel3");
        }
        if (level == 4)
        {
          
            SceneManager.LoadScene("BossStageScene");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
