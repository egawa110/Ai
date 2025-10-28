using UnityEngine;
using TMPro;
using System.Collections;

public class GamePauseController : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public bool FLAG        = false;
    public bool isPaused    = false;
    private bool isCooldown = false;

    public float cooldownTime = 5f; //�N�[���^�C��

    void Update()
    {
        //F�L�[�������ƃ|�[�Y
        if (Input.GetKeyDown(KeyCode.F) && !isPaused && !isCooldown)
        {
            StartCoroutine(PauseForSeconds(5f));
        }
    }

    IEnumerator PauseForSeconds(float seconds)
    {
        isPaused = true;
        isCooldown = true;

        //�v���C���[�ȊO�̓����I�u�W�F�N�g
        MovingObject[] movingObjects = FindObjectsOfType<MovingObject>();

        foreach (MovingObject obj in movingObjects)
        {
            if (!obj.CompareTag("Player"))
            {
                obj.enabled = false;
            }
        }

        EnemyContoroller[] enemies = FindObjectsOfType<EnemyContoroller>();

        foreach (EnemyContoroller enemy in enemies)
        {
            enemy.enabled = false;
        }


        //�J�E���g�_�E��
        for (int i = (int)seconds; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = ""; // �\��������


        //�ĊJ
        foreach (MovingObject obj in movingObjects)
        {
            obj.enabled = true;
        }


        foreach (EnemyContoroller enemy in enemies)
        {
            enemy.enabled = true;
            FLAG = true;
        }

        isPaused = false;

        //�N�[���^�C��
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;



    }
}
