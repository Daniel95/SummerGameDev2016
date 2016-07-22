﻿using UnityEngine;

public class AudioSetting : MonoBehaviour {

    private bool audioActive;

    void Start()
    {
        AudioActive = true;
        DontDestroyOnLoad(this.gameObject);
    }

    public bool AudioActive {
        get { return audioActive; }
        set { audioActive = value; }
    }
}
