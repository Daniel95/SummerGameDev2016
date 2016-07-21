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
        audioSetting.AudioActive = true;
    }

    public void SetAudioImage()
    {
        if (audioSetting.AudioActive)
        {
            audioImage.sprite = audioOff;
            audioSetting.AudioActive = false;
        }
        else
        {
            audioImage.sprite = audioOn;
            audioSetting.AudioActive = true;
        }
    }
}
