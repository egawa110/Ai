using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SkillCooldown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  //�e�L�X�g

    public float time = 0f;
    //���Ԓ�~
    public float count = 5f;
    private bool FLAG = false;
    //�X�s�[�hUP
    //�Q��
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
                countdownText.text = ""; // �\��������
                FLAG = false;
            }
        }
    }

}


