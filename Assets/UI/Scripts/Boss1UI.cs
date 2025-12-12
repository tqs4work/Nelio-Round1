using UnityEngine;
using UnityEngine.UI;

public class Boss1UI : MonoBehaviour
{
    [SerializeField] public Image hpBar;
    [SerializeField] private GameObject boss;
    void Start()
    {
        boss = GameObject.Find("Boss1");
    }
  
    void Update()
    {
        if(boss != null)
        {
            hpBar.fillAmount = boss.GetComponent<EnemyTakeDameController>().hp / boss.GetComponent<EnemyTakeDameController>().currentHp;
        }
        if(hpBar.fillAmount <= 0)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
