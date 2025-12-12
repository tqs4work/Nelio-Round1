using System.Collections;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [Header("Thông số nhân vật")]
    [SerializeField] float jumpForce;   
   
    public bool isFall;
    int t = 0;
    bool isJumping;
    float jumpTime;

    public bool isJump;

    bool liftBox;
    bool isAttack;
    bool isClimb;
    bool isWallSlide;
    bool isDash;
    bool isWJ;
    bool isDead;
    bool isHurt;

    float index;

    [Header("Unity Component")]
    Rigidbody2D rb;
    Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer;    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {  
        index = GetComponent<PanelCheckPoint>().Index;
        animator.SetBool("isGround",isGround());
        animator.SetBool("isFall", isFall);
        isAttack = GetComponent<PlayerAttackController>().isAttack;
        liftBox = GetComponent<PlayerPushPullController>().liftBox;
        isClimb = GetComponent<PlayerClimbController>().isClimb;
        isWallSlide = GetComponent<PlayerWallSlideController>().isWallSlide;
        isWJ = GetComponent<PlayerWallSlideController>().isWallJump;
        isDash = GetComponent<PlayerMovement>().isDash;
        isDead = GetComponent<PlayerLifeController>().isDead;
        isHurt = GetComponent<PlayerLifeController>().isHurt;
        if (liftBox == false && isAttack == false && isDash == false && isWallSlide == false && !isDead &&!isHurt && index > 0)
        {
            StartCoroutine(Jump());
        }

        if (isGround())
        {            
            isJumping = false;            
            isFall = false;   
            isJump = false;
        }          
        if(isWallSlide)
        {
            isJumping = true;
            isJump = true;
        }

        if (rb.linearVelocity.y < 0 && !isGround() && !isHurt)
        {
            isFall = true;            
        }

    }

    private void FixedUpdate()
    {
        
    }


    
    IEnumerator Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false &&  isClimb == false)
        {
            t += 1; //Debug.Log(t);
        }
        if (Input.GetKeyDown(KeyCode.Space) && (isGround()) && isClimb == false)
        {
            
            animator.SetTrigger("Jump");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpTime += Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
            isJump = true;
            yield return new WaitForSeconds(0.8f);
            t = 0;
        }
        if (t > 1 && jumpTime <= 0.5f && isJumping == false && isJump && index > 2)
        {
            t = 0;
            isJumping = true;
            animator.SetTrigger("Double_Jump");
            rb.AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
            yield return new WaitForSeconds(1f);            
            jumpTime = 0;
        }
    }

    public bool isGround()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.7f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, new Vector2(0.7f, 0.1f));
    }


}
