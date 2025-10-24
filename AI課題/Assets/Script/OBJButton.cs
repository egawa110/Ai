using UnityEngine;

public class OBJButton : MonoBehaviour
{
    public GameObject obj1;      //出現させるオブジェクト
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;

    private bool FLAG = false;

    public GamePauseController GP;  //時間停止フラグ

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  //プレイヤーがボタンに触れている
        {
            if(!GP.isPaused)  //時間が動いている時オブジェクトを表示
            {
                obj1.gameObject.SetActive(true);
                obj2.gameObject.SetActive(true);
                obj3.gameObject.SetActive(true);
                obj4.gameObject.SetActive(true);
                obj5.gameObject.SetActive(true);
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
                obj1.gameObject.SetActive(false);
                obj2.gameObject.SetActive(false);
                obj3.gameObject.SetActive(false);
                obj4.gameObject.SetActive(false);
                obj5.gameObject.SetActive(false);
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
                obj1.gameObject.SetActive(false);
                obj2.gameObject.SetActive(false);
                obj3.gameObject.SetActive(false);
                obj4.gameObject.SetActive(false);
                obj5.gameObject.SetActive(false);

                FLAG = false;  //FLAGを初期化
            }
        }
    }
}
