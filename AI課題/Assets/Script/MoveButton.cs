using UnityEngine;

public class MoveButton : MonoBehaviour
{
    private bool FLAG = false;
    public bool MoveFLAG = false;

    public GamePauseController GP;  //時間停止フラグ

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  //プレイヤーがボタンに触れている
        {
            if (!GP.isPaused)  //時間が動いている時オブジェクトを表示
            {
                MoveFLAG = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  //プレイヤーがボタンから離れた
        {
            Debug.Log("isPaused = " + GP.isPaused);
            if (!GP.isPaused)  //時間が動いている時はオブジェクトを削除
            {
                MoveFLAG = false;
            }
            if (GP.isPaused)  //時間が止まっている時FLAGをture
                FLAG = true;
        }
    }

    private void Update()
    {
        if (FLAG)  //時間が止まっている時にボタンから離れたら起動
        {
            if (!GP.isPaused)  //時間が再び動き出したときにオブジェクトを削除
            {
                MoveFLAG = false;
                FLAG = false;  //FLAGを初期化
            }
        }
    }


}
