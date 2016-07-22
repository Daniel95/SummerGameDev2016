using UnityEngine;
using System.Collections;

public class BallHitSound : MonoBehaviour {

    [SerializeField]
    private int maxSoundCooldown = 10;

    [SerializeField]
    private PlaySound playSound;

    private float soundCooldown;

    void Start() {
        playSound = GetComponent<PlaySound>();
        soundCooldown = maxSoundCooldown;
    }

    void OnCollisionEnter(Collision coll) {
        if(soundCooldown <= 0)
        {
            playSound.Play();
            soundCooldown = maxSoundCooldown;
        }
    }

    void Update()
    {
        soundCooldown--;
    }
}
