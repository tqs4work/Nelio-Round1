using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
    [Header("Thông số nhân vật")]
    bool isDead;
    bool isHurt;    
    float upNum = 10;
    public float takeNum = 0;
    float upCan = 0;
    public GameObject playerLight;
    public GameObject afterPrefab;

    float plight;


    [Header("Unity Components")]
    Rigidbody2D rb;
    Animator animator;

    GameObject PreUpHp;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PreUpHp = transform.Find("PreUpHp").gameObject;
    }

    // Update is called once per frame
    void Update()
    {       
        plight = playerLight.GetComponent<Light2D>().pointLightOuterRadius;
        isDead = GetComponent<PlayerLifeController>().isDead;
        isHurt = GetComponent<PlayerLifeController>().isHurt;
        if (isDead)
        {
            if(plight > 0)
            {
                playerLight.GetComponent<Light2D>().pointLightOuterRadius -= 10 * Time.deltaTime;

            }
        }


        if (takeNum >= upNum)
        {
            upCan += 1;
            takeNum -= 10;
        }

        if (upCan > 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                upCan -= 1;
                if (GetComponent<PlayerLifeController>().hp < 6) GetComponent<PlayerLifeController>().hp += 1;
                GameObject a = Instantiate(afterPrefab, transform.position, Quaternion.identity);
                a.gameObject.transform.SetParent(transform);
                Destroy(a, 1f);
            }
        }

        PreUpHp.SetActive(upCan > 0);


    }

    private void FixedUpdate()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Light"))
        {
            playerLight.GetComponent<Light2D>().pointLightOuterRadius += 0.25f;
            playerLight.GetComponent<Light2D>().pointLightInnerRadius += 0.25f;
            takeNum += 1;
            Destroy(collision.gameObject);
        }
    }
}
