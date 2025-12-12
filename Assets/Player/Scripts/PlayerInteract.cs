using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        if (collision.gameObject.CompareTag("NextScene"))
        {
            SceneManager.LoadScene("Dialog1_end");
            Destroy(collision.gameObject);
        }
    }



}
