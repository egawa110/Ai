using UnityEngine;

public class OBJButton : MonoBehaviour
{
    public GameObject obj1;      //�������I�u�W�F�N�g
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;

    private bool FLAG = false;
    public GamePauseController GP;  //���Ԓ�~�t���O

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  //�v���C���[���{�^���ɐG��Ă���
        {
            if(!GP.isPaused)  //���Ԃ������Ă��鎞�I�u�W�F�N�g��\��
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
        if (other.CompareTag("Player"))  //�v���C���[���{�^�����痣�ꂽ
        {
            Debug.Log("isPaused = " + GP.isPaused);
            if (!GP.isPaused)  //���Ԃ������Ă��鎞�̓I�u�W�F�N�g���폜
            {
                obj1.gameObject.SetActive(false);
                obj2.gameObject.SetActive(false);
                obj3.gameObject.SetActive(false);
                obj4.gameObject.SetActive(false);
                obj5.gameObject.SetActive(false);

            }
            if (GP.isPaused)  //���Ԃ��~�܂��Ă��鎞FLAG��ture
                FLAG = true;
        }
    }

    private void Update()
    {
        if (FLAG)  //���Ԃ��~�܂��Ă��鎞�Ƀ{�^�����痣�ꂽ��N��
        {
            if (!GP.isPaused)  //���Ԃ��Ăѓ����o�����Ƃ��ɃI�u�W�F�N�g���폜
            {
                obj1.gameObject.SetActive(false);
                obj2.gameObject.SetActive(false);
                obj3.gameObject.SetActive(false);
                obj4.gameObject.SetActive(false);
                obj5.gameObject.SetActive(false);

                FLAG = false;  //FLAG��������
            }
        }
    }
}
