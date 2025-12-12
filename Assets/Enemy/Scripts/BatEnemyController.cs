using System.Collections;
using UnityEngine;

public class BatEnemyController : MonoBehaviour
{
    [Header("Parameters")]
    float hp;
    public LayerMask playerMask;
    GameObject player;
    bool isRight;
    Vector3 direct;
    bool isRun;
    public Vector3 current;
    public Vector3 currentP;
    public float detectRange;
    bool isOnRoutine;
    float lastDetect;
    public bool isTarget;
    public GameObject hitPos;
    public float attackRange;
    bool isDead;
    bool isAttack;
    Vector3 startPos;
    float time;
    bool isSleep = true;

    Coroutine Sleep;

    [Header("Unity Components")]
    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");        
        startPos = transform.position;
    }
    
    void Update()
    {        
        Animate();
        hp = GetComponent<EnemyTakeDameController>().hp;
        isDead = GetComponent<EnemyTakeDameController>().isDead;          

        if(isDetect() || hp < 3)
        {
            isTarget = true;
            lastDetect = Time.time;
            if(!isAttack) Flip();
            if(!isOnRoutine) time += 0.005f;
            else
            {
                time = 0;
            }
            if (Sleep != null)
            {
                StopCoroutine(Sleep);
                isOnRoutine = false;
                Sleep = null;
            }
        }        

        if (isDead)
        {
            StopAllCoroutines();
        }        
    }

    private void FixedUpdate()
    {
        if (isDetect() && !isOnRoutine && time >= 2f)
        {
            if (isSleep)
            {
                WakeUp();
            }
            else
            {
                StartCoroutine(RunAct());
            }
        }

        if (!isDetect() && Time.time >= lastDetect + 3f && !isOnRoutine && isTarget)
        {
            Sleep = StartCoroutine(MoveBackStart());
            
        }
    }

    void Attack1()
    {
        animator.SetTrigger("Attack1");      
    }

    void Attack2()
    {
        animator.SetTrigger("Attack2");        
    }

    bool isDetect()
    {
        return Physics2D.OverlapCircle(transform.position, detectRange, playerMask);
    }   
    
    IEnumerator RunAct()
    {
        time = 0;
        isOnRoutine = true;        
        
        yield return new WaitForSeconds(2f);
        StartCoroutine (Action1());
        yield return StartCoroutine(Action1());
        StartCoroutine (Action2());
        yield return StartCoroutine(Action2());
        isOnRoutine = false;
    }
    
    IEnumerator Action1()
    {
        current = transform.position;
        if (player != null) currentP = player.transform.position;
        InvokeRepeating("Chase", 0, 0.01f);
        isRun = true;
        yield return new WaitForSeconds(0.6f);
        CancelInvoke();
        isRun = false;
        yield return new WaitForSeconds(0.1f);
        isAttack = true;
        Attack1();
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(Hit());
        yield return new WaitForSeconds(0.2f);
        isAttack = false;
    }

    IEnumerator Action2()
    {                
        isAttack = true;
        Attack2 ();
        yield return new WaitForSeconds(3/6f);        
        StartCoroutine(Hit());
        yield return new WaitForSeconds(1/6f);
        isAttack = false;
        InvokeRepeating("MoveAway", 0, 0.01f);
        isRun = true;
        yield return new WaitForSeconds(0.6f);
        CancelInvoke ();
        isRun = false;
        yield return new WaitForSeconds(1f);
    }


    void Animate()
    {
        animator.SetBool("Run", isRun);
        animator.SetBool("Detect", isTarget);
    }
    
    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentP, 5f * 0.005f);
    }

    void MoveAway()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentP + new Vector3(Random.Range(-4,4), Random.Range(0, 2),0), 5f * 0.005f);
    }

    void WakeUp()
    {
        animator.SetTrigger("Wake");
        isSleep = false;
    }

    IEnumerator MoveBackStart()
    {
        isOnRoutine = true;
        InvokeRepeating("MoveStart", 0, 0.01f);
        yield return new WaitForSeconds(3f);
        CancelInvoke();  
        isOnRoutine= false;
        if (Vector3.Distance(transform.position, startPos) < 0.1f)
        {
            isTarget = false;           
            isSleep = true;
        }
        
    }

    void MoveStart()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPos, 3f * 0.005f);
    }

    void Flip()
    {
        if (player != null)
        {
            if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = Vector3.one;
            }
            if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    IEnumerator Hit()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(hitPos.transform.position, attackRange, playerMask);

        foreach (Collider2D col in player)
        {
            if (col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<PlayerLifeController>().isImute == false)
            {                
                StartCoroutine(col.GetComponent<PlayerLifeController>().TakeDame(1f));
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.DrawWireSphere(hitPos.transform.position, attackRange);
    }
   
}
