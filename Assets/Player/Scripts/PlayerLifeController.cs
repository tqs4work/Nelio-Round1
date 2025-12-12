using System;
using System.Collections;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    [Header("Thông số nhân vật")]
    public float hp = 3f;
    public bool isDead;
    public bool isHurt;
    public bool isImute;    
    public Vector3 savePosVip;
    Vector3 savePos;
    bool isGround;
    bool isClimb;
    float maxDisFall = 10f;
    bool isFall;
    float maxHigh = 0;

    [Header("Unity Components")]
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
        isClimb = GetComponent<PlayerClimbController>().isClimb;
        isGround = GetComponent<PlayerJumpController>().isGround();
        isFall = GetComponent<PlayerJumpController>().isFall;
        animator.SetBool("Dead",isDead);
        if (hp <= 0)
        {
            StartCoroutine(Dead());
        }     
                
        StartCoroutine(FallDame());
    }

    public IEnumerator TakeDame(float dame)
    {
        animator.SetTrigger("Hurt");
        hp -= dame;
        isHurt = true;
        isImute = true;
        rb.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;        
        yield return new WaitForSeconds(0.4f);        
        isHurt = false;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;        
        yield return new WaitForSeconds(1f);
        isImute = false;
    }

    IEnumerator Dead()
    {
        isDead = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }    

    IEnumerator FallDame()
    {        
        float temp = rb.linearVelocity.y;      
        yield return new WaitForSeconds(0.1f);
        if (temp / rb.linearVelocity.y < 0 && !isGround)
        {
            maxHigh = transform.position.y;
            //Debug.Log("MH = " + maxHigh);
        }
        if(isClimb)
        {
            maxHigh = transform.position.y;            
        }
        if (isGround) 
        {
            float fallDis = maxHigh - transform.position.y;
            //Debug.Log("FD = " + fallDis);
            if (fallDis > maxDisFall)
            {
                StartCoroutine(TakeDame(1f));
                if (!isDead) transform.position = savePos;
                fallDis = 0f;
                maxHigh = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;
        
        if (collision.gameObject.CompareTag("Trap") && !isImute)
        {
            StartCoroutine(TakeDame(1));            
        }
        if (collision.gameObject.CompareTag("Deadzone"))
        {
            StartCoroutine(TakeDame(1));
            if (!isDead) transform.position = savePos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        if(collision.gameObject.CompareTag("SavePoint"))
        {
            savePos = collision.gameObject.transform.position;
        }        
    }
}
