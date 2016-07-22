using UnityEngine;

public class PlaySound : MonoBehaviour {

    [SerializeField]
    private AudioClip audioClip;

    private AudioSource audioSource;

    private AudioSetting audioSetting;

    private bool audioSettingExists = false;

    // Use this for initialization
    void Awake()
    {
        if (GameObject.FindGameObjectWithTag(Tags.AUDIOSETTING.ToString()) != null)
        {
            audioSettingExists = true;
            audioSetting = GameObject.FindGameObjectWithTag(Tags.AUDIOSETTING.ToString()).GetComponent<AudioSetting>();
        }
       
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if(!audioSettingExists || audioSetting.AudioActive)
        {
            if (audioClip != null)
                audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}