using System.Collections;
using UnityEngine;

public class PlayerClimbController : MonoBehaviour
{
    [Header("Thông số nhân vật")]
    public bool isClimb;
    Vector2 move;
    float xCollision;
    bool liftBox;
    bool isDead;

    [Header("Unity Component")]
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        liftBox = GetComponent<PlayerPushPullController>().liftBox;
        isDead = GetComponent<PlayerLifeController>().isDead;
        if (liftBox==false && !isDead)
        {
            move = new Vector2(0, Input.GetAxis("Vertical"));
            Climb();
        }        
        animator.SetBool("Climb",isClimb);
    }
    private void FixedUpdate()
    {        
    }

    void Climb()
    {
        if (isClimb)
        {
            
            animator.SetFloat("MoveY", Mathf.Abs(move.y));            

            transform.position = new Vector3(xCollision,transform.position.y,0);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.linearVelocity = new Vector2(0, move.y * 4f);
            }
            else
            {
                rb.linearVelocity = new Vector2(0, move.y * 2f);
            }
            
        }
        
    }
           
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Ladder"))
            {
                if (GetComponent<PlayerJumpController>().isGround() == false && move.y != 0)
                {
                    isClimb = true;
                    rb.gravityScale = 0f;
                    xCollision = collision.transform.position.x;
                }
                if (GetComponent<PlayerJumpController>().isGround() == true && move.y > 0)
                {
                    isClimb = true;
                    rb.gravityScale = 0f;
                    xCollision = collision.transform.position.x;
                }
                if ((GetComponent<PlayerJumpController>().isGround() && move.y < 0))
                {
                    isClimb = false;
                    rb.gravityScale = 1f;
                }
            }

            if (collision.gameObject.CompareTag("LadderTop"))
            {
                if(move.y < 0)
                {
                    collision.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    collision.transform.parent.gameObject.transform.Find("Ground").gameObject.SetActive(false);
                }
                
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {            
            if (collision.gameObject.CompareTag("Ladder"))
            {
                isClimb = false;
                rb.gravityScale = 1f;                         
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.CompareTag("LadderTop"))
            {
                collision.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.transform.parent.gameObject.transform.Find("Ground").gameObject.SetActive(true);
            }
            if (collision.gameObject.CompareTag("LadderSide"))
            {
                
                collision.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                collision.transform.parent.gameObject.transform.Find("Ground").gameObject.SetActive(false);
                

            }
        }
    }
}
