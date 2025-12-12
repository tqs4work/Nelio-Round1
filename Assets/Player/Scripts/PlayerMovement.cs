using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Thông số nhân vật")]
    public float moveSpeed;    
    public Vector2 move;
    public bool isDash;
    bool canDash = true;
    bool groundDash;
    bool isClimb;
    bool liftBox;
    bool isAttack;
    bool isWallSlide;
    bool isWJ;
    bool isDead;
    bool isHurt;

    float index;

    float timeDash;
    [SerializeField] GameObject ghostPrefabs;
    

    [Header("Unity Component")]
    Rigidbody2D rb;
    Animator animator;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame (k cố định)
    void Update()
    {
        index = GetComponent<PanelCheckPoint>().Index;
        isClimb = GetComponent<PlayerClimbController>().isClimb;
        liftBox = GetComponent<PlayerPushPullController>().liftBox;
        isAttack = GetComponent<PlayerAttackController>().isAttack;
        isWallSlide = GetComponent<PlayerWallSlideController>().isWallSlide;
        isWJ = GetComponent<PlayerWallSlideController>().isWallJump;
        isDead = GetComponent<PlayerLifeController>().isDead;
        isHurt = GetComponent<PlayerLifeController>().isHurt;
        //isGround = GetComponent<PlayerJumpController>().isGround();
        if (isDash == false && isAttack == false && !isDead && !isHurt && index > -1)
        {
            if (MenuManager.instance.isPaused) return;
            move = new Vector2(Input.GetAxis("Horizontal"), 0);            
        }
        
        
        if (liftBox == false && !isWallSlide)
        {
            animator.SetFloat("MoveX", Mathf.Abs(move.x));
            if(!isWJ) Flip();
            moveSpeed = 5f;
        }
        if (liftBox == true)
        {
            if (GetComponent<PlayerPushPullController>().direct > 0)
            {
                animator.SetFloat("MoveX", move.x);
            }
            else
            {
                animator.SetFloat("MoveX", -move.x);
            }
            moveSpeed = 1.5f;
        }

        if (isClimb == false && liftBox == false && isAttack == false && index > 4)
        {
            StartCoroutine(Dash());
        }  
        
        GetComponent<PlayerLifeController>().isImute = (isDash);

    }
    // 50 lần mỗi giây (cố định)
    private void FixedUpdate()
    {
        if (isClimb == false && isWJ == false && !isWallSlide)
        {
            rb.linearVelocity = new Vector2(move.x * moveSpeed, rb.linearVelocity.y);
        }
    }
    void Flip()
    {
        if (move.x < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (move.x > 0) transform.localScale = Vector3.one;
    }

    IEnumerator Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true && groundDash == false && !isWJ && !isWallSlide && !isHurt)
        {
            if (GetComponent<PlayerJumpController>().isGround())
            {                
                groundDash = true;   
                timeDash = Time.time;
            }
            isDash = true;
            canDash = false;
            rb.AddForce(new Vector2(transform.localScale.x * 300f, 0));
            rb.gravityScale = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            animator.SetTrigger("Dash");            
            InvokeRepeating("SpawnDash", 0.1f, 0.1f);
            move.x = transform.localScale.x;
            yield return new WaitForSeconds(1/3f);   
            CancelInvoke("SpawnDash");
            isDash = false;
            moveSpeed = 5f;
            rb.gravityScale = 1f;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            yield return new WaitForSeconds(0.01f);
            //groundDash = false;
        }
        if ((GetComponent<PlayerJumpController>().isGround()||isWallSlide) && canDash == false)
        {
            if (groundDash && Time.time < timeDash + 0.7f && !Input.GetKeyDown(KeyCode.Space))
            {               
                canDash = false;
            }
            else
            {
                canDash = true;
                groundDash = false;
            }
        }        
    }


    void SpawnDash()
    {
        GameObject ghost = Instantiate(ghostPrefabs, transform.position, transform.rotation);
        ghost.transform.localScale = transform.localScale;
        Destroy(ghost, 0.5f);
    }

}
