using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SkillCooldown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  //テキスト
    public TextMeshProUGUI count_sText;  //テキスト

    public float time = 0f;
    //時間停止
    public float count = 5f;
    private bool FLAG = false;
    //スピードUP
    public float count_s = 5f;
    public bool FLAG2 = false;
    //参照
    public GamePauseController GP;
    public Skill_Speed S_SP;

    void Update()
    {
        if (GP.isPaused)
        {
            time = count;
            FLAG = true;
        }
        if(FLAG)
        {
            time -= Time.deltaTime;
            countdownText.text = Mathf.Ceil(time).ToString() + "";
            if (time <= 0f)
            {
                countdownText.text = ""; // 表示を消す
                FLAG = false;
            }
        }

        if (S_SP.FLAG_S)
        {
            time = count_s;
            FLAG2 = true;
        }
        if (FLAG2)
        {
            time -= Time.deltaTime;
            count_sText.text = Mathf.Ceil(time).ToString() + "";
            if (time <= 0f)
            {
                count_sText.text = ""; // 表示を消す
                FLAG2 = false;
                S_SP.FLAG_S = false;
            }
        }

    }

}


