using UnityEngine;

public class FlyGroundController : MonoBehaviour
{
    public bool right;
    Vector3 current;    
    Vector3 direct;    
    void Start()
    {
        current = transform.position;
        if(right) direct = Vector3.right; 
        else direct = Vector3.left;       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direct * Time.deltaTime;       
        if (Vector3.Distance(transform.position, current + 3 * direct) < 0.1f)
        {            
            direct = (direct == Vector3.right) ? Vector3.left : Vector3.right;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform, true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.activeInHierarchy)
            {
                collision.transform.SetParent(null);
            }
        }
    }
}
