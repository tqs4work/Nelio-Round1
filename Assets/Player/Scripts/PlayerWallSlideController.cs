using System.Collections;
using UnityEngine;

public class PlayerWallSlideController : MonoBehaviour
{
    [Header("Thông số nhân vật")]

    float moveInput;
    bool isGround;
    public bool isWallSlide;
    bool isHurt;
    bool isDead;
    
    bool isDash;
    public bool isWallJump;
    float wjDirect;
    float wjCounter;
    float wjTime = 0.2f;
    float wjDuration = 0.4f;
    float ws;

    float direct;

    [Header("Unity Component")]
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public Transform wallCheck;
    public LayerMask wallLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        isGround = GetComponent<PlayerJumpController>().isGround();
        isDash = GetComponent<PlayerMovement>().isDash;
        isHurt = GetComponent<PlayerLifeController>().isHurt;
        isDead = GetComponent<PlayerLifeController>().isDead;
        animator.SetBool("Wall_Slide",isWallSlide);
        animator.SetBool("WJ",isWallJump);
        animator.SetFloat("WS", ws);
        

        if (isDash==false && !isDead && !isHurt) 
        {
            WallSlide();
            WallJump();
        }
    }


    void WallSlide()
    {
        if (isWall() && !isGround && moveInput/direct > 0 && !isWallJump)
        {
            isWallSlide = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -1f, float.MaxValue));            
        }
        else
        {
            isWallSlide = false;
        }
        
    }

    void WallJump()
    {
        if (isWallSlide)
        {
            isWallJump = false;
            if(!isWallJump) wjDirect = -transform.localScale.x;
            wjCounter = wjTime;
            
            ws += Time.deltaTime;            
            spriteRenderer.flipX = true;


            CancelInvoke(nameof(StopWJ));
        }
        else
        {
            wjCounter -= Time.deltaTime;
            if(!isWallJump) spriteRenderer.flipX = false;
            ws = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && wjCounter > 0f)
        {            
            isWallJump = true;
            rb.linearVelocity = new Vector2(wjDirect * 5f, 6f);
            //rb.AddForce(new Vector2(wjDirect * 5f, 5f), ForceMode2D.Impulse);
            wjCounter = 0f;

            Invoke(nameof(StopWJ),wjDuration);

        }
    }

    void StopWJ()
    {
        isWallJump = false;
    }


    public bool isWall()
    {
        return Physics2D.OverlapCapsule(wallCheck.position, new Vector2(0.1f, 0.5f), CapsuleDirection2D.Vertical, 0, wallLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(wallCheck.position, new Vector2(0.1f, 0.5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;
        if(collision.gameObject.CompareTag("Wall"))
        {
            direct = transform.localScale.x;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

}
