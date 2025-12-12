using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ManyEyesController : MonoBehaviour
{
    [Header("Many Eyes Settings")]
    [SerializeField] float speed;
    [SerializeField] GameObject hitF1;
    [SerializeField] GameObject hitF2;
    [SerializeField] GameObject hitB;
    [SerializeField] float f1Range;
    [SerializeField] float f2Range;
    [SerializeField] float bRange;
    float detectRange = 5f;
    float attackRange = 2f;
    bool isDead;
    bool isAttack;
    bool isTarget;
    Vector3 direct;
    bool isInRange;
    float scaleX;
    bool isBack;
    bool isOnRoutine;
    Coroutine currentRoutine;
    float timer;
    float hp;
    


    [Header("Unity Components")]
    Animator animator;
    Rigidbody2D rb;
    GameObject player;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        direct = Vector3.right;
        player = GameObject.Find("Player");
        isDead = GetComponent<EnemyTakeDameController>().isDead;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
   
    void Update()
    {
        CheckRange();
        hp = GetComponent<EnemyTakeDameController>().hp;
        if (isDetect())
        {
            timer = Time.time;
        }

        if(isDead)
        {
            StopAllCoroutines();
            CancelInvoke("Walking");
            CancelInvoke("Chase");
            isOnRoutine = false;
            isAttack = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }        

    }

    void FixedUpdate()
    {
        if (isDetect() || hp < GetComponent<EnemyTakeDameController>().currentHp)
        {
            if (currentRoutine != null) { StopCoroutine(currentRoutine); currentRoutine = null;  }
        }


        if (isDetect() && !isOnRoutine)
        {
            
            StartCoroutine(Action1());
        }

        if(!isDetect() && !isOnRoutine && Time.time > timer + 3f)
        {
            if(currentRoutine == null) currentRoutine =  StartCoroutine(Action0());
        }

        if (!isAttack && isDetect())
        {
            Flip();
        }
    }

    IEnumerator Action0()
    {
        isOnRoutine = true;
        animator.SetBool("Run", true);
        InvokeRepeating("Walking", 0, 0.01f);
        yield return new WaitForSeconds(4f);
        CancelInvoke("Walking");
        animator.SetBool("Run", false);
        yield return new WaitForSeconds(2f);
        direct = -direct;
        yield return new WaitForSeconds(0.2f);
        transform.localScale = new Vector3(direct == Vector3.right ? 1 : -1, 1, 1);     
        isOnRoutine = false;
        //StartCoroutine(Action0());
    }

    IEnumerator Action1()
    {
        isOnRoutine = true;
        animator.SetBool("Run", true);
        InvokeRepeating("Chase", 0, 0.01f);
        yield return new WaitUntil(() => isInRange == true || Time.time > timer + 3f);
        CancelInvoke("Chase");
        animator.SetBool("Run", false);
        if (isInRange)
        {
            isAttack = true;
            Attack1();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(0.25f);
            HitF1();
            yield return new WaitForSeconds(0.5f);
            HitF2();
            yield return new WaitForSeconds(0.25f);            
        }        
        yield return new WaitForSeconds(0.1f);        
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        scaleX = transform.localScale.x;
        yield return new WaitForSeconds(0.2f);
        CheckBack();
        yield return new WaitForSeconds(0.1f);
        if(isBack)
        {
            Attack2();
            isAttack = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(0.7f);
            HitB();
            yield return new WaitForSeconds(0.3f);
            isAttack = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            isAttack = false;
        }
        yield return new WaitForSeconds(1f);
        Flip();
        yield return new WaitForSeconds(0.2f);
        isOnRoutine = false;
        //StartCoroutine(Action1());

    }
    

    void Flip()
    {
        if (player == null) return;
        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = Vector3.one;            
        }
        else
        {
            transform.localScale = new Vector3(-1,1,1);            
        }
    }

    void CheckBack()
    {
        if (player == null) return;
        if ( (scaleX < 0 && transform.position.x < player.transform.position.x) || (scaleX > 0 && transform.position.x > player.transform.position.x))
        {
            isBack = true;
        }
        else
        {
            isBack = false;
        }
    }

    void CheckRange()
    {
        if(player == null) return;
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            isInRange = true;
        }
        else
        {
            isInRange = false;
        }
    }

    void Walking()
    {
        transform.Translate(direct * 0.005f * speed);
    }
    
    void Chase()
    {
        if(player!=null) transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.005f * speed * 2);
    }

    void Attack1()
    {
        animator.SetTrigger("Attack1");
    }

    void Attack2()
    {
        animator.SetTrigger("Attack2");
    }

    void Animate()
    {        
        animator.SetBool("Attack", isAttack);
        animator.SetBool("Target", isTarget);
    }

    bool isDetect()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, detectRange, LayerMask.GetMask("Player"));
        if (collider != null)
        {
            return true;
        }
        return false;
    }

    void HitF1()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(hitF1.transform.position, f1Range, LayerMask.GetMask("Player"));
        foreach (Collider2D col in player)
        {
            if (col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<PlayerLifeController>().isImute == false)
            {
                col.gameObject.GetComponent<PlayerLifeController>().StartCoroutine("TakeDame", 1f);
            }
        }
    }

    void HitF2()
    {
        Collider2D[] player = Physics2D.OverlapBoxAll(hitF2.transform.position, new Vector2(5, 1), 0, LayerMask.GetMask("Player"));
        foreach (Collider2D col in player)
        {
            if (col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<PlayerLifeController>().isImute == false)
            {
                col.gameObject.GetComponent<PlayerLifeController>().StartCoroutine("TakeDame", 1f);
            }
        }
    }

    void HitB()
    {
        Collider2D[] player = Physics2D.OverlapCapsuleAll(hitB.transform.position, new Vector2(1, 2), CapsuleDirection2D.Vertical, -38 , LayerMask.GetMask("Player"));
        foreach (Collider2D col in player)
        {
            if (col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<PlayerLifeController>().isImute == false)
            {
                col.gameObject.GetComponent<PlayerLifeController>().StartCoroutine("TakeDame", 1f);
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, detectRange);
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(hitF1.transform.position, f1Range);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(hitF2.transform.position, f2Range);
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireCube(hitB.transform.position, new Vector3(1, 2));
    //}


    public Vector3 size = new Vector3(1, 2, 0); // Đổi size thành Vector3
    public CapsuleDirection2D direction = CapsuleDirection2D.Vertical;
    public float angle = -38;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Chọn màu cho Gizmos

        Gizmos.DrawWireSphere(transform.position, detectRange);

        // Tính toán vị trí trung tâm của capsule
        Vector3 center = hitB.transform.position;

        // Tính toán các điểm
        Vector3 top = center + Quaternion.Euler(0, 0, angle) * new Vector3(0, size.y / 2, 0);
        Vector3 bottom = center + Quaternion.Euler(0, 0, angle) * new Vector3(0, -size.y / 2, 0);
        Vector3 left = center + Quaternion.Euler(0, 0, angle) * new Vector3(-size.x / 2, 0, 0);
        Vector3 right = center + Quaternion.Euler(0, 0, angle) * new Vector3(size.x / 2, 0, 0);

        // Vẽ hình trụ (capsule)
        Gizmos.DrawWireSphere(top, size.x / 2); // Đỉnh
        Gizmos.DrawWireSphere(bottom, size.x / 2); // Đáy
        Gizmos.DrawLine(left, top); // Bên trái
        Gizmos.DrawLine(right, top); // Bên phải
        Gizmos.DrawLine(left, bottom); // Bên trái
        Gizmos.DrawLine(right, bottom); // Bên phải



        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(hitF1.transform.position, f1Range);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(hitF2.transform.position, new Vector2(5,1));

    }


}
