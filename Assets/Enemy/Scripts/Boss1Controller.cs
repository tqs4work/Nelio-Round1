using System.Collections;
using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    [SerializeField] GameObject ghostPrefabs;
    [SerializeField] GameObject jaPrefabs;

    Vector3 direct;
    //float moveSpeed = 3f;
    float timer;

    float dashCoolDown = 3f;
    
    float jumpCoolDown = 3f;

    float timeRoll;
    float rollCoolDown = 1f;
    public int rollNum;

    bool isAttack;

    bool isDead;
    bool isPlayerDead;

    [Header("Hit F1")]
    [SerializeField] GameObject hit1Pos;
    [SerializeField] Vector2 hit1Range;

    [SerializeField] GameObject hit2Pos;
    [SerializeField] Vector2 hit2Range;

    [Header("Unity Component")]
    Rigidbody2D rb;
    Animator animator; 
    GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direct = Vector3.left;
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        isDead = GetComponent<EnemyTakeDameController>().isDead; 
        if (player != null) isPlayerDead = player.GetComponent<PlayerLifeController>().isDead;

        if (isPlayerDead)
        {
            return;
        }

        if (player!=null) direct = (GameObject.Find("Player").transform.position.x > transform.position.x) ? Vector3.right : Vector3.left;

        if (Time.time >= timeRoll + rollCoolDown && !isDead)
        {
            Roll();
        }

        if (Time.time >= timer + dashCoolDown && rollNum == 1 && !isDead)
        {
            StartCoroutine(Dash());
        }
        else if (Time.time >= timer + jumpCoolDown && rollNum == 2 && !isDead)
        {
            StartCoroutine(JumpAttack());
        }

        if (isDead)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StopAllCoroutines();
        }
        transform.localScale = (direct == Vector3.right) ? Vector3.one : new Vector3(-1, 1, 1);
    }

    private void Roll()
    {
        timeRoll = Time.time;
        rollNum = Random.Range(1, 3);
    }

    IEnumerator Dash()
    {
        timer = Time.time;
        isAttack = true;
        animator.SetTrigger("Dash");
        rb.AddForce(direct * 300f);
        InvokeRepeating("SpawnDash", 0f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        CancelInvoke("SpawnDash");
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger("Attack1");
        yield return new WaitForSeconds(0.3f);
        Hit1();
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
    }

    void SpawnDash()
    {
        GameObject ghost = Instantiate(ghostPrefabs, transform.position, transform.rotation);
        ghost.transform.localScale = transform.localScale;
        Destroy(ghost, 0.5f);        
    }

    IEnumerator JumpAttack()
    {
        timer = Time.time;
        isAttack = true;
        animator.SetTrigger("Jump");
        rb.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
        rb.AddForce(direct * 100f);
        yield return new WaitForSeconds(1f);
        rb.AddForce(new Vector2(0, -5f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.7f);
        SpawnJAPrefab();
        Hit2();
        yield return new WaitForSeconds(0.2f);
        isAttack = false;

    }

    void SpawnJAPrefab()
    {
        GameObject ja1 = Instantiate(jaPrefabs, transform.position + Vector3.down * 0.5f, Quaternion.identity);
        GameObject ja2 = Instantiate(jaPrefabs, transform.position + Vector3.down * 0.5f, Quaternion.Euler(0,180,0));
        Destroy(ja1, 0.5f);
        Destroy(ja2, 0.5f);
    }

    void Hit1()
    {
        Collider2D[] player = Physics2D.OverlapBoxAll(hit1Pos.transform.position, hit1Range, 0 , LayerMask.GetMask("Player"));

        if (player.Length > 0) // Kiểm tra xem có collider nào được quét không
        {
            foreach (Collider2D col in player)
            {                
                if (col.gameObject.CompareTag("Player") && !col.gameObject.GetComponent<PlayerLifeController>().isImute)
                {
                    Debug.Log("Hit Player");
                    col.gameObject.GetComponent<PlayerLifeController>().StartCoroutine("TakeDame", 1f);
                }
            }
        }        

    }

    void Hit2()
    {
        Collider2D[] player = Physics2D.OverlapBoxAll(hit2Pos.transform.position, hit2Range, 0, LayerMask.GetMask("Player"));

        if (player.Length > 0) // Kiểm tra xem có collider nào được quét không
        {
            foreach (Collider2D col in player)
            {
                if (col.gameObject.CompareTag("Player") /*&& !col.gameObject.GetComponent<PlayerLifeController>().isImute*/)
                {
                    Debug.Log("Hit Player");
                    col.gameObject.GetComponent<PlayerLifeController>().StartCoroutine("TakeDame", 1f);
                }
            }
        }

    }


    void Animate()
    {        
        animator.SetBool("Ground", isGround());
        animator.SetBool("isAttack", isAttack);
    }

    bool isGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.8f, LayerMask.GetMask("Ground"));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Chọn màu cho Gizmos
        Gizmos.DrawWireCube(hit1Pos.transform.position, hit1Range);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(hit2Pos.transform.position, hit2Range);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.8f);
    }
    

}
