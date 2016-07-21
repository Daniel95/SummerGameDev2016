using UnityEngine;
using System.Collections;

public class ActivateParticle : MonoBehaviour {

    private ParticleSystem particleSystem;

	// Use this for initialization
	void Start () {
        particleSystem = GetComponent<ParticleSystem>();
	}
	
    public void Activate()
    {
        particleSystem.Play();
    }
}
