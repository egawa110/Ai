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
        //最初の目的地を設定
        target = pointB;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //現在の位置から目的地へ移動
        transform.position = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);

        //目的地に到達したら、次の目的地に切り替え
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;

            spriteRenderer.flipX = !spriteRenderer.flipX;
        }



    }


}
