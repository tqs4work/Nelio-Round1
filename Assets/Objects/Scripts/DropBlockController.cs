using System.Collections;
using UnityEngine;

public class DropBlockController : MonoBehaviour
{
    Vector3 current;
    Vector3 direct;
    Rigidbody2D rb;
    void Start()
    {
        current = transform.position;
        direct = Vector3.right;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direct * Time.deltaTime * 0.1f;
        if(Mathf.Abs(transform.position.x - current.x) > 0.01f)
        {
            direct = (direct == Vector3.right) ? Vector3.left : Vector3.right;  
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerJumpController>().isGround())
            {
                StartCoroutine(Drop());
            }
        }
    }

    IEnumerator Drop()
    {
        yield return new WaitForSeconds(1.5f);
        rb.linearVelocity = new Vector2(0, -5f);
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
