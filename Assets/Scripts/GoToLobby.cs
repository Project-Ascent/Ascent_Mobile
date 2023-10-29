using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToLobby : MonoBehaviour
{

    public void SceneChange()
    {
        if (ItemSelected.IS.item == "b")
            Item.item.beans = true;
        else if (ItemSelected.IS.item == "a")
            Item.item.airballon = true;
        else if (ItemSelected.IS.item == "g")
            Item.item.goose = true;
        print("GoToLobby");
        SceneManager.LoadScene("LobbyScene");
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
