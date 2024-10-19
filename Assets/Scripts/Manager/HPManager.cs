using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public static HPManager Instance {  get; private set; }
    private int HP = 3;
    private int maxHP = 3;
    private bool isInvincible;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void DecreaseHP(int damage)
    {
        HP = Math.Max(0, HP - damage);
        if (HP == 0)
        {
            GameManager.Instance.LoadSceneWithName("GameOverScene");
        }
    }

    public void IncreaseHP(int amount)
    {
        HP = Math.Min(maxHP, HP + amount);
    }

    public bool GetIsInvincible() {  return isInvincible; }
    public void SetIsInvincible(bool val) { isInvincible = val; }
}
