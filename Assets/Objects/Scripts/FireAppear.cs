using System.Collections;
using UnityEngine;

public class FireAppear : MonoBehaviour
{
    GameObject player;
    SpriteRenderer spriteRenderer;
    bool isActive = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {        
        if(player == null) return;
        if(Vector3.Distance(transform.position, player.transform.position) < 5f && !isActive) 
        {
            isActive = true;
            StartCoroutine(Active());
        }       
    }

    private IEnumerator Active()
    {
        
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }    


}
