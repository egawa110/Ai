using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SkillCooldown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  //テキスト

    public float time = 0f;
    //時間停止
    public float count = 5f;
    private bool FLAG = false;
    //スピードUP
    //参照
    public GamePauseController GP;

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
    }

}


