using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("UI Objects")]
    public Image[] hearts;
    public Image[] arcanas;
    public Image[] bossHealthUI;
    public Image[] buffs;
    public Text timerText;
    [Header("Variables")]
    public int health = 3;
    public float timeValue = 80f;
    public bool BossLevel;
    public int arcanaCounter;
    public bool[] ArcanaConquer;
    public float BossHP = 100f;
    public float MaxBossHP = 100f;

    void Start()
    {
        //Turn off buffs at start of the game
        for(int i = 0;i < buffs.Length; i++)
        {
            buffs[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //HUD Health decreases from PlayerMovement script
        //Health
        UpdateHealth();
        //Update Time
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        } else {
            timeValue = 0;
        }
        //Timer
        DisplayTime(timeValue);
        //Arcana Cards
        DisplayArcanas();
        //Boss HP
        DisplayBossHP();
        //Display Arcana Buffs
        DisplayBuffs();
    }
    //UI
    void DisplayBuffs()
    {
        buffs[0].enabled = ArcanaConquer[0];
        buffs[1].enabled = ArcanaConquer[1];
        buffs[2].enabled = ArcanaConquer[2];
    }

    void DisplayBossHP()
    {
        if(BossLevel)
        {
            bossHealthUI[0].enabled = true;
            bossHealthUI[0].fillAmount = BossHP/MaxBossHP;
            bossHealthUI[1].enabled = true;
        } else {
            bossHealthUI[0].enabled = false;
            bossHealthUI[1].enabled = false;
        }
    }

    void DisplayArcanas()
    {
        if(BossLevel)
        {
            for(int i = 0;i < arcanas.Length; i++)
            {
                arcanas[i].fillAmount = 0;
            }
        } else {
            arcanas[arcanaCounter].fillAmount = 1;
        }
    }

    void DisplayTime(float time)
    {
        if(time < 0)
        {
            time = 0;
        }

        float mins = Mathf.FloorToInt(time / 60);
        float secs = Mathf.FloorToInt(time % 60);
        //Display
        timerText.text = string.Format("{0:00}:{1:00}", mins, secs);
    }


    void UpdateHealth()
    {
        switch(health)
        {
            case 3:
                hearts[0].fillAmount = 1;
                hearts[1].fillAmount = 1;
                hearts[2].fillAmount = 1;
                break;
            case 2:
                hearts[0].fillAmount = 1;
                hearts[1].fillAmount = 1;
                hearts[2].fillAmount = 0;
                break;
            case 1:
                hearts[0].fillAmount = 1;
                hearts[1].fillAmount = 0;
                hearts[2].fillAmount = 0;
                break;
            default:
                hearts[0].fillAmount = 0;
                hearts[1].fillAmount = 0;
                hearts[2].fillAmount = 0;
                break;
        }
    }
}
