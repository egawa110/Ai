using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;
    public float speed2 = 5f;

    private Vector3 target;

    public MoveButton MB;

    void Start()
    {
        target = pointB;

    }

    void Update()
    {
        if (MB.MoveFLAG)
        {

            transform.position = Vector3.MoveTowards(transform.position, pointB, speed2 * Time.deltaTime);
        }
        if(!MB.MoveFLAG)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);
        }

    }
}
