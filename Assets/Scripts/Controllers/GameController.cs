using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;
    //[SerializeField]
    //private GameObject pauseButton;
    //[SerializeField]
    //private GameObject restartButton;
    //[SerializeField]
    //private GameObject audioButton;
    //[SerializeField]
    //private GameObject pauseMenuRestartButton;
    //[SerializeField]
    //private GameObject pauseMenuResumeButton;
    //[SerializeField]
    //private GameObject pauseMenuMainMenuButton;

    // Use this for initialization
    void Start () {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
	}

    public void Pause()
    {
        if (pauseMenu != null)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
    public void Resume()
    {
        if (pauseMenu != null)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void Restart()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void ChangeScene(string nameScene)
    {
        //destroy all objects in current screen.
        DontDestroyOnLoad(this);
        //show mainmenu
        SceneManager.LoadScene(nameScene);
        Time.timeScale = 1;
    }
}
