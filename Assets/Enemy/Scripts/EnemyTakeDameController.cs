using System.Collections;
using UnityEngine;

public class EnemyTakeDameController : MonoBehaviour
{
    public float hp;
    public float currentHp;
    public bool isDead;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    public GameObject lightPrefab;
    GameObject light1 = null;
    GameObject light2 = null;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Dead",isDead);
    }


    public void TakeDame(float dame)
    {
        hp -= dame;
        animator.SetTrigger("Hurt");
        //StartCoroutine(ChangeColor());
        if (hp <= 0)
        {
            isDead = true;
            rb.gravityScale = 1;            
            Destroy(this.gameObject, 1.5f);
            if(light1 == null && light2 == null)
            {
                StartCoroutine(SpawnLight());
                if (currentHp >= 5) StartCoroutine(SpawnLight());
                if (currentHp >= 10) StartCoroutine(SpawnLight());
            }
        }
    }

    Color ori;
    Color target;
    float colorTimer;
    IEnumerator ChangeColor()
    {
        ori = Color.white;
        target = new Color(250/255f , 175/255f, 175/255f, 1);
        InvokeRepeating("changeColorr", 0, 0.01f);
        yield return new WaitForSeconds(0.2f);
        CancelInvoke("changeColorr");
        ori = new Color(250 / 255f, 175 / 255f, 175 / 255f, 1);
        target = Color.white;
        InvokeRepeating("changeColorr", 0, 0.01f);
        yield return new WaitForSeconds(0.2f);
        CancelInvoke("changeColorr");
        spriteRenderer.color = Color.white;
    }

    void changeColorr()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.Lerp(ori, target, colorTimer + 0.01f);
        }
    }


    IEnumerator SpawnLight()
    {
        light1 = Instantiate(lightPrefab, transform.position + new Vector3(Random.Range(0f,1.5f), Random.Range(0f, 1f), 0), Quaternion.identity);
        light2 = Instantiate(lightPrefab, transform.position + new Vector3(Random.Range(-1.5f, 0f), Random.Range(0f, 1f), 0), Quaternion.identity);      
        //if (light1 != null) light1.GetComponent<Rigidbody2D>().gravityScale = 1;
        //if (light2 != null) light1.GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PBullet"))
        {
            TakeDame(1);
            Destroy(collision.gameObject);

        }
    }
}
