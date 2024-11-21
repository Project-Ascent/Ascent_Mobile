using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UILifeManager : MonoBehaviour
{
    [SerializeField]
    private Image[] lifeImgArr;

    void Awake()
    {
        if (lifeImgArr.Length != HPManager.Instance.MaxHP)
        {
            lifeImgArr = new Image[HPManager.Instance.MaxHP];
        }
    }

    public void UpdateLifeUI(int curHP)
    {
        for (int i = 0; i < HPManager.Instance.MaxHP; i++)
        {
            lifeImgArr[i].enabled = (i < curHP);
        }
    }
}
