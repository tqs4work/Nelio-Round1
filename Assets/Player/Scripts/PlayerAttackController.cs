using System.Collections;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [Header("Thông số nhân vật")]
    [SerializeField] Transform hitPos;
    [SerializeField] GameObject firePos;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float attackRange;
    bool isClimb;

    public bool isAttack;
    bool liftBox;
    bool isWallSlide;
    bool isDash;
    bool isHurt;

    float index;

    [Header("Unity Component")]
    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();        
        isHurt = GetComponent<PlayerLifeController>().isHurt;
    }
    
    void Update()
    {
        index = GetComponent<PanelCheckPoint>().Index;
        isClimb = GetComponent<PlayerClimbController>().isClimb;
        liftBox = GetComponent<PlayerPushPullController>().liftBox;
        isWallSlide = GetComponent<PlayerWallSlideController>().isWallSlide;
        isDash = GetComponent<PlayerMovement>().isDash;
        if (isClimb==false && liftBox==false && !isWallSlide && !isAttack && !isHurt && index > 5)
        {
            StartCoroutine(MeleeAttack());
            StartCoroutine(RangedAttack());
            StartCoroutine(JumpAttack());
            StartCoroutine(JumpRangedAttack());
            //StartCoroutine(PowerAttack());
        }
        
    }
    
    IEnumerator MeleeAttack()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<PlayerJumpController>().isGround() &&  !isDash)
        {
            isAttack = true;
            animator.SetTrigger("Attack1");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(0.1f);
            Hit();
            yield return new WaitForSeconds(0.4f);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            isAttack = false;
        }

    }

    IEnumerator RangedAttack()
    {
        if (Input.GetMouseButtonDown(1) && GetComponent<PlayerJumpController>().isGround() && !isDash)
        {
            isAttack = true;
            animator.SetTrigger("Ranged_Attack");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(35 / 60f);
            SpawnBullet();
            yield return new WaitForSeconds(10 / 60f);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            isAttack = false;
        }
    }

    IEnumerator JumpAttack()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent <PlayerJumpController>().isJump && !isDash)
        {
            isAttack = true;
            GetComponent<PlayerJumpController>().isJump = false;
            animator.SetTrigger("Jump_Attack");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(5 / 60f);
            Hit();
            yield return new WaitForSeconds(35 / 60f);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(new Vector2(0,0.1f),ForceMode2D.Impulse);
            isAttack = false;
        }
    }

    IEnumerator JumpRangedAttack()
    {
        if (Input.GetMouseButtonDown(1) && GetComponent<PlayerJumpController>().isJump && !isDash)
        {
            isAttack = true;
            GetComponent<PlayerJumpController>().isJump = false;
            animator.SetTrigger("Jump_Ranged_Attack");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(35 / 60f);
            SpawnBullet();
            yield return new WaitForSeconds(5 / 60f);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(new Vector2(0, 0.1f), ForceMode2D.Impulse);
            isAttack = false;
        }
    }

    IEnumerator PowerAttack()
    {
        if (Input.GetKeyDown(KeyCode.R) && GetComponent<PlayerJumpController>().isGround() && !isDash)
        {
            StartCoroutine(GetComponent<PlayerUIController>().PowerPan());
            isAttack = true;
            animator.SetTrigger("Intro_PA");
            animator.SetBool("Power_Attack", true);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            yield return new WaitForSeconds(3f);
            animator.SetBool("Power_Attack", false);
            yield return new WaitForSeconds(0.5f);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            isAttack = false;
        }
    }

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePos.transform.position, Quaternion.identity);
        if (bullet != null)
        {
            bullet.GetComponent<P_BulletController>().direct = (transform.localScale.x > 0) ? Vector3.right : Vector3.left;
        }
    }

    void Hit()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitPos.position, attackRange);

        foreach (Collider2D c in enemies)
        {
            if(c.gameObject.CompareTag("Enemy"))
            {
                c.GetComponent<EnemyTakeDameController>().TakeDame(1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(hitPos.position, attackRange);
    }

}
