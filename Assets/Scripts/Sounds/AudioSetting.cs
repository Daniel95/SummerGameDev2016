using UnityEngine;

public class AudioSetting : MonoBehaviour {

    private bool audioActive;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(Tags.AUDIOSETTING.ToString()).Length > 1)
            Destroy(this.gameObject);

        AudioActive = true;
        DontDestroyOnLoad(this.gameObject);
    }

    public bool AudioActive {
        get { return audioActive; }
        set { audioActive = value; }
    }
}
