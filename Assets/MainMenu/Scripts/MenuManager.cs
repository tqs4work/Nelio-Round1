using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public bool isPaused = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayNew()
    {
        SceneManager.LoadScene("Dialog1");

    }
    public void QuitGame()
    {
        Debug.Log("Quitting game..."); // Sẽ thấy log này trong Editor
        Application.Quit();
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Tiếp tục thời gian trong game
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Tạm dừng thời gian trong game
    }
}
