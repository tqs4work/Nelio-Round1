using System.Collections;
using UnityEngine;

public class Boss1FightController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject boss1;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject fench1;
    [SerializeField] private GameObject fench2;
    [SerializeField] private GameObject activePoint;
    [SerializeField] private GameObject fire1;
    [SerializeField] private GameObject fire2;
    [SerializeField] private GameObject fire3;
    [SerializeField] private GameObject fire4;
    [SerializeField] private GameObject lightS;
    [SerializeField] private GameObject canvas;

    
    private bool camActive = false;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (player == null) return;
        if (Vector3.Distance(player.transform.position, activePoint.transform.position) < 0.1f && !camActive)
        {
            camActive = true;
            StartCoroutine(Intro());            
        }

        if(canvas != null && canvas.GetComponent<Boss1UI>().hpBar.fillAmount <= 0)
        {
            StartCoroutine(Outro());            
        }

    }

    IEnumerator Intro()
    {
        cam.SetActive(true);
        if (player != null)
        {
            player.GetComponent<PlayerAttackController>().isAttack = true;
            player.GetComponent<PlayerMovement>().move = Vector2.zero;
        }
        yield return new WaitForSeconds(1f);
        lightS.SetActive(true);
        yield return new WaitForSeconds(1f);
        fench1.SetActive(true);
        yield return new WaitForSeconds(1f);        
        fench2.SetActive(true);
        yield return new WaitForSeconds(1f);    
        fire1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fire2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fire3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fire4.SetActive(true);
        yield return new WaitForSeconds(1f);
        if (player != null) player.GetComponent<PlayerAttackController>().isAttack = false;
        boss1.SetActive(true);
        canvas.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator Outro()
    {
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        fench1.GetComponent<Fench>().up = true;
        fench2.GetComponent<Fench>().up = true;
        yield return new WaitForSeconds(1f);
        cam.SetActive(false);
    }




}
