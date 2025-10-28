using TMPro;
using UnityEngine;

public class Skill_Speed : MonoBehaviour
{
    public float Speed = 5f;     //UP����X�s�[�h
    public float OrigineSpeed = 0f;     //���X�̃X�s�[�h
    //�\�͂̌��ʎ���
    public float time = 0f;
    public float count = 10f;
    //�N�[���^�C��
    public float timeC = 0f;
    public float countC = 5f;

    public bool FLAG   = false;
    public bool FLAG2  = false;
    public bool FLAG_S = false;

    public GameObject CooldownUI;
    public TextMeshProUGUI SpeedUp_Text;  //�e�L�X�g
    public TextMeshProUGUI Cooldown_Text;  //�e�L�X�g
    public PlayerController controller;

    void Start()
    {
        OrigineSpeed = controller.moveSpeed;

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) //R�L�[�������ꂽ�珈��
        {
            if (!FLAG_S && !FLAG2)
            {
                controller.moveSpeed += Speed;
                time = count;
                timeC = countC;
                CooldownUI.SetActive(true);
            }
            FLAG_S = true;
            FLAG = true;
        }
        if(FLAG2) //�\�͂̌��ʂ��؂ꂽ�珈��
        {
            controller.moveSpeed = OrigineSpeed;

            //�\�͂̃N�[���_�E��
            timeC -= Time.deltaTime;
            Cooldown_Text.text = Mathf.Ceil(timeC).ToString() + "";
            if (timeC <= 0f)
            {
                Cooldown_Text.text = ""; // �\��������
                FLAG2 = false;
            }
        }

        if (FLAG)�@//�\�͂̌��ʎ���
        {
            time -= Time.deltaTime;
            SpeedUp_Text.text = Mathf.Ceil(time).ToString() + "";
            if (time <= 0f)
            {
                SpeedUp_Text.text = ""; // �\��������
                FLAG = false;
                FLAG_S = false;
                FLAG2 = true;
                CooldownUI.SetActive(false);
            }
        }
    }
}
