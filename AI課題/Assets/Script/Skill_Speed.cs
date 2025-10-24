using UnityEngine;

public class Skill_Speed : MonoBehaviour
{
    public float Speed = 5f;
    public float OrigineSpeed = 0f;
    public bool FLAG_S = false;
    public PlayerController controller;
    public SkillCooldown SK_D;

    void Update()
    {
        OrigineSpeed = controller.moveSpeed;
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (!FLAG_S)
            {
                controller.moveSpeed += Speed;
            }
            FLAG_S = true;
        }
        if(!SK_D.FLAG2)
        {
            controller.moveSpeed = OrigineSpeed;
        }
    }
}
