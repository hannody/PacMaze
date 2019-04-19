using UnityEngine.SceneManagement;
using UnityEngine;


public class UIGameOverController : MonoBehaviour
{
    public Transform gameOverPanel;
    public static UIGameOverController instance = null;

    private void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        if(gameOverPanel == null)
        {
           gameOverPanel =  GameObject.FindGameObjectWithTag(Tags.gameOverPanel).transform;
        }
        EnableGameOverPanel(false);
    }

    public void EnableGameOverPanel(bool enable)
    {
        gameOverPanel.gameObject.SetActive(enable);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
