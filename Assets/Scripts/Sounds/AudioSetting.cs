using UnityEngine;
using System;

public class AudioSetting : MonoBehaviour {

    public Action<bool> changeAudioSetting;

    private bool audioActive;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(Tags.AUDIOSETTING.ToString()).Length > 1)
            Destroy(this.gameObject);

        audioActive = true;
        DontDestroyOnLoad(this.gameObject);
    }

    public bool AudioActive {
        get { return audioActive; }
    }

    public void SwitchAudioActive() {
        audioActive = !audioActive;
        if (changeAudioSetting != null)
            changeAudioSetting(audioActive);
    }

    public void SetAudioActive(bool _active)
    {
        audioActive = _active;
        if (changeAudioSetting != null)
            changeAudioSetting(audioActive);
    }
}
