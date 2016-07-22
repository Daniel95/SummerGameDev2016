using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject finishMenu;
    [SerializeField]
    private Text finishShootText;
    [SerializeField]
    private Text finishCoinsText;

    private ScoreTracker scoreTracker;
    private SceneLoader sceneLoader;
    private const string defaultFinishCoinsText = "Munten: ";
    private const string defaultFinishShootText = "Schoten: ";

    // Use this for initialization
    void Start () {

        sceneLoader = GetComponent<SceneLoader>();
        scoreTracker = GetComponent<ScoreTracker>();

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
        finishShootText.text = defaultFinishShootText + scoreTracker.shotCount.ToString();
        if (scoreTracker.coinCollected)
            finishCoinsText.text = defaultFinishCoinsText + "Munten Verzameld!";
        else
            finishCoinsText.text = defaultFinishCoinsText + "Geen Munt Verzameld";
        finishMenu.SetActive(true);
    }

}
