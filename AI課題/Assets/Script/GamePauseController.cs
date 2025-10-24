using UnityEngine;
using TMPro;
using System.Collections;

public class GamePauseController : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public bool isPaused = false;
    private bool isCooldown = false;

    public float cooldownTime = 5f; //クールタイム

    void Update()
    {
        //Fキーを押すとポーズ
        if (Input.GetKeyDown(KeyCode.F) && !isPaused && !isCooldown)
        {
            StartCoroutine(PauseForSeconds(5f));
        }
    }

    IEnumerator PauseForSeconds(float seconds)
    {
        isPaused = true;
        isCooldown = true;

        //プレイヤー以外の動くオブジェクト
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


        //カウントダウン
        for (int i = (int)seconds; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = ""; // 表示を消す


        //再開
        foreach (MovingObject obj in movingObjects)
        {
            obj.enabled = true;
        }


        foreach (EnemyContoroller enemy in enemies)
        {
            enemy.enabled = true;
        }

        isPaused = false;

        //クールタイム
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;



    }
}
