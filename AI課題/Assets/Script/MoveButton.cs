using UnityEngine;

public class MoveButton : MonoBehaviour
{
    public bool FLAG = false;
    public bool MoveFLAG = false;

    public GamePauseController GP;  //時間停止フラグ

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  //プレイヤーがボタンに触れている
        {
                MoveFLAG = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  //プレイヤーがボタンから離れた
        {
            Debug.Log("isPaused = " + GP.isPaused);
            MoveFLAG = false;
        }
    }
}
