using UnityEngine;
using UnityEngine.UIElements;

public class BoxController : MonoBehaviour
{
    bool liftBox;
    GameObject player;
    Rigidbody2D rb;

    public bool blockBox;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) liftBox = player.GetComponent<PlayerPushPullController>().liftBox;

        if (liftBox)
        {                       
            rb.linearVelocity = new Vector2(0,0);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Enemy"))
            {
                if (liftBox)
                {
                    blockBox = true;
                }
            }
        }        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Enemy"))
        {
            if (liftBox)
            {
                blockBox = false;
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ChallengeRect"))
        {
            collision.gameObject.GetComponent<Block2TorchChallenge>().active++;
        }
    }
}
