using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject finishMenu;

    private SceneLoader sceneLoader;

    // Use this for initialization
    void Start () {
        //if (GameObject.FindObjectsOfType<GameController>().Length > 1) {
        //    Destroy(this.gameObject);
        //}
        sceneLoader = GetComponent<SceneLoader>();
      //  DontDestroyOnLoad(this);


        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
	}

    private void OnEnable()
    {
        sceneLoader = GetComponent<SceneLoader>();
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
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        finishMenu.SetActive(false);
        sceneLoader.LoadCurrentScene();

    }

    public void Finish()
    {
        finishMenu.SetActive(true);
    }
}
