using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image fadeImage;
    public GameObject tip;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject panel9;
    public GameObject panel10;


    public Button OK1;
    public Button OK2;
    public Button OK3;
    public Button OK4;
    public Button OK5;
    public Button OK6;
    public Button OK7;
    public Button OK8;
    public Button OK9;
    public Button OK10;


    //public GameObject panel2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        OK1.onClick.AddListener(() => ClosePanel(panel1));
        OK2.onClick.AddListener(() => ClosePanel(panel2));
        OK3.onClick.AddListener(() => ClosePanel(panel3));
        OK4.onClick.AddListener(() => ClosePanel(panel4));
        OK5.onClick.AddListener(() => ClosePanel(panel5));
        OK6.onClick.AddListener(() => ClosePanel(panel6));
        OK7.onClick.AddListener(() => ClosePanel(panel7));
        OK8.onClick.AddListener(() => ClosePanel(panel8));
        OK9.onClick.AddListener(() => ClosePanel(panel9));
        OK10.onClick.AddListener(() => ClosePanel(panel10));
        StartCoroutine(fadeit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fadeit()
    {
        yield return new WaitForSeconds(1f);
        InvokeRepeating("changecolor", 0f, 0.05f);
        yield return new WaitForSeconds(3f);
        CancelInvoke("changecolor");
        yield return new WaitForSeconds(0.5f);
        fadeImage.gameObject.SetActive(false);
        tip.SetActive(true);

    }

    float step = 1f;
    void changecolor()
    {
        step -= 0.01f;
        fadeImage.color = new Color(0, 0, 0, step);
    }

    void ClosePanel(GameObject panel)
    {
        if(panel != null)
        {
            panel.SetActive(false);
        }
        MenuManager.instance.ResumeGame();
    }
    public void ShowPanel(float index)
    {
        if (index == 0 && panel1 != null)
        {
            panel1.SetActive(true);
            MenuManager.instance.PauseGame();
        }
            
        if (index == 1 && panel2 != null)
        {
            panel2.SetActive(true);
            MenuManager.instance.PauseGame();
        }
        else if (index == 2 && panel3 != null)
        {
            panel3.SetActive(true);
            MenuManager.instance.PauseGame();
        }
        else if (index == 3 && panel4 != null)
        {
            panel4.SetActive(true);
            MenuManager.instance.PauseGame();
        }
        else if (index == 4 && panel5 != null)
        {
            panel5.SetActive(true);
            MenuManager.instance.PauseGame();
        }
        else if (index == 5 && panel6 != null)
        {
            panel6.SetActive(true);
            MenuManager.instance.PauseGame();
        }
        else if (index == 6 && panel7 != null)
        {
            panel7.SetActive(true);
            MenuManager.instance.PauseGame();
        }
        else if (index == 7 && panel8 != null)
        {
            panel8.SetActive(true);
            MenuManager.instance.PauseGame();
        }
        else if (index == 8 && panel9 != null)
        {
            panel9.SetActive(true);
            MenuManager.instance.PauseGame();
        }
        else if (index == 9 && panel10 != null)
        {
            panel10.SetActive(true);
            MenuManager.instance.PauseGame();
        }
    }

}
