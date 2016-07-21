using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    private PlaySound playSound;

	// Use this for initialization
	void Start () {
        playSound = GetComponent<PlaySound>();
        playSound.Play();
	}
}
