using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audioSource.Play();
    }
}