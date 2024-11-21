using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public static HPManager Instance {  get; private set; }
    private int maxHP = 3;
    public int CurHP { get; private set; }
    public bool IsInvincible { get; set; } = false;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        CurHP = maxHP;
        DontDestroyOnLoad(gameObject);
    }

    public void DecreaseHP(int damage)
    {
        CurHP = Math.Max(0, CurHP - damage);
        Debug.Log("ÇöÀç HP : " + CurHP);
        if (CurHP == 0)
        {
            GameManager.Instance.LoadSceneWithName("GameOverScene");
        }
    }

    public void IncreaseHP(int amount)
    {
        CurHP = Math.Min(maxHP, CurHP + amount);
    }
}
