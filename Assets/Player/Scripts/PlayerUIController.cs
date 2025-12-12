using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public Image[] hearts;
    public Image[] fireflys;
    public GameObject GOPan;
    public GameObject TAFF;
    public GameObject QFF;
    float hp;
    GameObject PowerPanel;
    void Start()
    {
        PowerPanel = GameObject.Find("PlayerUICanvas").gameObject.transform.Find("PowerPan").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        hp = GetComponent<PlayerLifeController>().hp;
        UpdateHP();  
        UpdateFL();

        GOPan.SetActive(hp <= 0);
    }

    void UpdateHP()
    {
        for (int i = 0; i < 6; i++)
        {
            hearts[i].enabled = i < hp;
        }
    }
    void UpdateFL()
    {
        for (int i = 0; i < 6; i++)
        {
            fireflys[i].enabled = i < hp;
        }
    }

    public IEnumerator PowerPan()
    {
       
        PowerPanel.SetActive(true);
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 1f;
        PowerPanel.SetActive(false);
        
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Map");
    }

    public void TAFFin()
    {
        TAFF.SetActive(true);
    }
    public void TAFFout()
    {
        TAFF.SetActive(false);
    }

    public void QFFin()
    {
        QFF.SetActive(true);
    }
    public void QFFout()
    {
        QFF.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

}
