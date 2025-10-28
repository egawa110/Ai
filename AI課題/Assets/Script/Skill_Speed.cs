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

    public TextMeshProUGUI count_sText;  //テキスト
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

        //クールダウン処理
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
                count_sText.text = ""; // 表示を消す
                FLAG = false;
                FLAG_S = false;
            }
        }

    }
}
