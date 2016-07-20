using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private GameObject audioButton;
    [SerializeField]
    private GameObject pauseMenuRestartButton;
    [SerializeField]
    private GameObject pauseMenuResumeButton;
    [SerializeField]
    private GameObject pauseMenuMainMenuButton;

    // Use this for initialization
    void Start () {

        pauseMenu.SetActive(false);
	}

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        //destroy all objects in current screen.
        DontDestroyOnLoad(this);
        //show mainmenu
        SceneManager.LoadScene("Default");
    }
}
