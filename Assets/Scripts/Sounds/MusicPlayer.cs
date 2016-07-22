using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    private AudioSetting audioSetting;

    private PlaySound playSound;

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag(Tags.AUDIOSETTING.ToString()) != null)
        {
            audioSetting = GameObject.FindGameObjectWithTag(Tags.AUDIOSETTING.ToString()).GetComponent<AudioSetting>();
        }

        if (audioSetting != null)
            audioSetting.changeAudioSetting += ChangedAudioSetting;

        playSound = GetComponent<PlaySound>();
        playSound.Play();
    }

    void OnEnable() {
        if (audioSetting != null)
            audioSetting.changeAudioSetting += ChangedAudioSetting;
    }

    void OnDisable() {
        if (audioSetting != null)
            audioSetting.changeAudioSetting -= ChangedAudioSetting;
    }

    void ChangedAudioSetting(bool _active) {
        if (_active)
            playSound.Play();
        else
            playSound.Stop();
    }
}
