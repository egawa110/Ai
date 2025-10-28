using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SkillCooldown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  //テキスト
    public GameObject CooldownUI;

    public float time = 0f;
    //時間停止
    public float count = 5f;
    //スピードUP
    //参照
    public GamePauseController GP;

    void Update()
    {
        if (GP.isPaused)
        {
            time = count;
            CooldownUI.SetActive(true);
        }
        if(!GP.isPaused)
        {
            CooldownUI.SetActive(false);
        }
        if (GP.FLAG)
        {
            time -= Time.deltaTime;
            countdownText.text = Mathf.Ceil(time).ToString() + "";
            if (time <= 0f)
            {
                countdownText.text = ""; // 表示を消す
                GP.FLAG = false;
            }
        }
    }

}


