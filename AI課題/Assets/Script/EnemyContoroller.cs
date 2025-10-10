using UnityEngine;

public class EnemyContoroller : MonoBehaviour
{
    public Vector3 pointA = new Vector3(-3f, 0f, 0f);
    public Vector3 pointB = new Vector3( 3f, 0f, 0f);
    public float MoveSpeed = 1.0f;

    private Vector3 target;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        //�ŏ��̖ړI�n��ݒ�
        target = pointB;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //���݂̈ʒu����ړI�n�ֈړ�
        transform.position = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);

        //�ړI�n�ɓ��B������A���̖ړI�n�ɐ؂�ւ�
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;

            spriteRenderer.flipX = !spriteRenderer.flipX;
        }



    }


}
