using UnityEngine;

public class MoveButton : MonoBehaviour
{
    private bool FLAG = false;
    public bool MoveFLAG = false;

    public GamePauseController GP;  //���Ԓ�~�t���O

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  //�v���C���[���{�^���ɐG��Ă���
        {
            if (!GP.isPaused)  //���Ԃ������Ă��鎞�I�u�W�F�N�g��\��
            {
                MoveFLAG = true;
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
                MoveFLAG = false;
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
                MoveFLAG = false;
                FLAG = false;  //FLAG��������
            }
        }
    }


}
