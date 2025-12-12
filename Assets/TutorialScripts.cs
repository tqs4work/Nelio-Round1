using UnityEngine;

public class TutorialScripts : MonoBehaviour
{
    public GameObject paneltut1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggelActive()
    {
        if (paneltut1 != null)
        {
            paneltut1.SetActive(!paneltut1.activeSelf);
        }
    }

}
