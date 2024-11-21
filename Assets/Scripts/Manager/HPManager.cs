using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public static HPManager Instance { get; private set; }
    private UILifeManager uiLifeManager;
    public int MaxHP { get; private set; } = 3;
    private int curHP;
    public bool IsInvincible { get; set; } = false;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        curHP = MaxHP;
        uiLifeManager = FindObjectOfType<UILifeManager>();
        DontDestroyOnLoad(gameObject);
    }

    public void DecreaseHP(int damage)
    {
        curHP = Math.Max(0, curHP - damage);
        uiLifeManager?.UpdateLifeUI(curHP);
        if (curHP == 0)
        {
            GameManager.Instance.LoadSceneWithName("GameOverScene");
        }
    }

    public void IncreaseHP(int amount)
    {
        curHP = Math.Min(MaxHP, curHP + amount);
        uiLifeManager?.UpdateLifeUI(curHP);
    }
}
