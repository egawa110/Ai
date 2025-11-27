using TMPro;
using UnityEngine;

public class Skill_Speed : MonoBehaviour
{
    public float Speed = 3f;     //UPするスピード
    public float OrigineSpeed = 0f;     //元々のスピード
    //能力の効果時間
    public float time = 0f;
    public float count = 10f;
    //クールタイム
    public float timeC = 0f;
    public float countC = 5f;

    public bool FLAG   = false;
    public bool FLAG2  = false;
    public bool FLAG_S = false;

    public GameObject CooldownUI;
    public TextMeshProUGUI SpeedUp_Text;  //テキスト
    public TextMeshProUGUI Cooldown_Text;  //テキスト
    public PlayerController controller;

    void Start()
    {
        OrigineSpeed = controller.moveSpeed;

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) //Rキーを押されたら処理
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
        if(FLAG2) //能力の効果が切れたら処理
        {
            controller.moveSpeed = OrigineSpeed;

            //能力のクールダウン
            timeC -= Time.deltaTime;
            Cooldown_Text.text = Mathf.Ceil(timeC).ToString() + "";
            if (timeC <= 0f)
            {
                Cooldown_Text.text = ""; // 表示を消す
                FLAG2 = false;
            }
        }

        if (FLAG)　//能力の効果時間
        {
            time -= Time.deltaTime;
            SpeedUp_Text.text = Mathf.Ceil(time).ToString() + "";
            if (time <= 0f)
            {
                SpeedUp_Text.text = ""; // 表示を消す
                FLAG = false;
                FLAG_S = false;
                FLAG2 = true;
                CooldownUI.SetActive(false);
            }
        }
    }
}
