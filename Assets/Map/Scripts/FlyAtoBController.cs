using UnityEngine;

public class FlyAtoBController : MonoBehaviour
{
    public Transform pointA, pointB;
    Transform target;
    public float flySpeed;
    void Start()
    {
        target = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, flySpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.activeInHierarchy)
            {
                collision.transform.SetParent(null);
            }
        }
    }
}
