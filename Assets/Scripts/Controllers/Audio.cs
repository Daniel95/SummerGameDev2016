using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    [SerializeField]
    private AudioSetting audioSetting;

    [SerializeField]
    private Image audioImage;

    [SerializeField]
    private Sprite audioOn;

    [SerializeField]
    private Sprite audioOff;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag(Tags.AUDIOSETTING.ToString()) != null)
        {
            audioSetting = GameObject.FindGameObjectWithTag(Tags.AUDIOSETTING.ToString()).GetComponent<AudioSetting>();
            SetStartAudioImage();
        }
    }

    private void SetStartAudioImage()
    {
        if(audioSetting.AudioActive)
        {
            audioImage.sprite = audioOn;
        }
        else
        {
            audioImage.sprite = audioOff;
        }
    }

    public void SetAudioImage()
    {
        if (audioSetting.AudioActive)
        {
            audioImage.sprite = audioOff;
            audioSetting.SetAudioActive(false);
        }
        else
        {
            audioImage.sprite = audioOn;
            audioSetting.SetAudioActive(true);
        }
    }
}
