using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    [SerializeField]
    private Image audioImage;

    [SerializeField]
    private Sprite audioOn;

    [SerializeField]
    private Sprite audioOff;

    private bool isAudioOn;

    private void Start()
    {
        isAudioOn = true;
    }

    public void SetAudioImage()
    {
        if (isAudioOn)
        {
            audioImage.sprite = audioOff;
            isAudioOn = false;
        }
        else
        {
            audioImage.sprite = audioOn;
            isAudioOn = true;
        }
    }


}
