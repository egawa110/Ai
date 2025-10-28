using TMPro;
using UnityEngine;

public class Skill_Speed : MonoBehaviour
{
    public float Speed = 5f;
    public float OrigineSpeed = 0f;
    public float time = 0f;
    public float count = 5f;

    public bool FLAG   = false;
    public bool FLAG2  = false;
    public bool FLAG_S = false;

    public TextMeshProUGUI count_sText;  //�e�L�X�g
    public PlayerController controller;

    void Start()
    {
        OrigineSpeed = controller.moveSpeed;

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (!FLAG_S)
            {
                controller.moveSpeed += Speed;
            }
            FLAG_S = true;
        }
        if(FLAG2)
        {
            controller.moveSpeed = OrigineSpeed;
        }

        //�N�[���_�E������
        if (FLAG_S)
        {
            time = count;
        }
        if (FLAG)
        {
            time -= Time.deltaTime;
            count_sText.text = Mathf.Ceil(time).ToString() + "";
            if (time <= 0f)
            {
                count_sText.text = ""; // �\��������
                FLAG = false;
                FLAG_S = false;
            }
        }

    }
}
