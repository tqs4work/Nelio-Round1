using UnityEngine;

public class PanelCheckPoint : MonoBehaviour
{
    public float Index=-1;
    public Canvas UIControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Panelcheckpoint"))
        {
            Index++;
            UIController uictrl = UIControl.GetComponent<UIController>();
            uictrl.ShowPanel(Index);
            Destroy(collision.gameObject);
        }
        
    }
}
