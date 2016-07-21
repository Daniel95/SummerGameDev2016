using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        audioSource.Play();
    }
}