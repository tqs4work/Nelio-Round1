using UnityEngine;

public class PlayerPushPullController : MonoBehaviour
{
    [Header("Thông số nhân vật")]
    
    Vector2 touchBoxPos;

    public bool nearBox;
    public float direct;
    public bool liftBox;

    public Transform groundCheck;
    public LayerMask boxLayer;

    [Header("Unity Component")]
    Rigidbody2D rb;
    Animator animator;
    GameObject Box;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }
    
    void Update()
    {
        animator.SetBool("LiftBox", liftBox);
        if (nearBox)
        {
            if (Input.GetKeyDown(KeyCode.E) && isOnBox()==false)
            {
                liftBox = !liftBox;                                
            }
            if (liftBox)
            {
                if (Box != null)
                {
                    if (Box.GetComponent<BoxController>().blockBox == false)
                    {
                        Box.transform.position = transform.position + new Vector3(0.75f * direct, -0.3f);
                    }
                    else
                    {
                        if (direct > 0 && GetComponent<PlayerMovement>().move.x > 0)
                        {
                            Box.transform.position = Box.transform.position;
                            GetComponent<PlayerMovement>().move.x = 0;
                        }
                        else if (direct > 0 && GetComponent<PlayerMovement>().move.x < 0)
                        {
                            Box.transform.position = transform.position + new Vector3(0.75f * direct, -0.3f);
                        }

                        if (direct < 0 && GetComponent<PlayerMovement>().move.x < 0)
                        {
                            Box.transform.position = Box.transform.position;
                            GetComponent<PlayerMovement>().move.x = 0;
                        }
                        else if (direct < 0 && GetComponent<PlayerMovement>().move.x > 0)
                        {
                            Box.transform.position = transform.position + new Vector3(0.75f * direct, -0.3f);
                        }
                    }
                    transform.localScale = new Vector3(direct, 1, 1);
                    Box.GetComponent<Rigidbody2D>().mass = 1;
                }
                
            }     
            if (!liftBox)
            {
                if(Box != null)
                {
                    Box.GetComponent<Rigidbody2D>().mass = 500;
                    
                }
                
            }
        }
        
        if (Box != null)
        {            
            if (Vector3.Distance(transform.position, Box.transform.position) > 1f)
            {
                nearBox = false;
                Box = null;
            }
        }
                
    }


    public bool isOnBox()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.1f), CapsuleDirection2D.Horizontal, 0, boxLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && Box == null)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                nearBox = true;

                direct = transform.localScale.x;
                
            }
        }

        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                if (Box == null)
                {
                    Box = collision.gameObject;
                }
                
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                
            }
        }
    }

}
