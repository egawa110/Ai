using UnityEngine;
using TMPro;
using System.Collections;

public class GamePauseController : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    private bool isPaused = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T) && !isPaused)
        {
            StartCoroutine(PauseForSeconds(5f));
        }
    }

    IEnumerator PauseForSeconds(float seconds)
    {
        isPaused = true;

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


    }
}
