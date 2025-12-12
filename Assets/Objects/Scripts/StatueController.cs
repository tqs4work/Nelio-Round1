using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Splines.Interpolators;

public class StatueController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float cPercent;
    [SerializeField] GameObject lightS;  
    bool isActive;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActive)
        {
            isActive = true;
            StartCoroutine(ChangeColor());
            collision.GetComponent<PlayerLifeController>().savePosVip = this.gameObject.transform.position;
        }

    }

    IEnumerator ChangeColor()
    {
        InvokeRepeating("ChangeCL", 0.1f, 0.1f);
        yield return new WaitForSeconds(1f);
        CancelInvoke("ChangeCL");
    }

    void ChangeCL()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, cPercent);
        cPercent += 0.1f;
        lightS.GetComponent<Light2D>().pointLightOuterRadius += 0.1f;
        lightS.GetComponent<Light2D>().pointLightInnerRadius += 0.1f;
    }
    

}
