using UnityEngine;

public class Trampoline : MonoBehaviour {

    [SerializeField]
    private float yStrength;

    [SerializeField]
    private float yMultiplier;

    private PlaySound playSound;

    private IBallVelocity IBallVelocity;

    void Start() {
        IBallVelocity = GameObject.FindGameObjectWithTag(Tags.BALL.ToString()).GetComponent<IBallVelocity>();
        playSound = GetComponent<PlaySound>();
    }

    void OnTriggerEnter(Collider _collider) {
        if (_collider.CompareTag(Tags.BALL.ToString()))
        {
            playSound.Play();
            IBallVelocity.MultiplyGivenAxes(new Vector3(yMultiplier, 1, yMultiplier));
            IBallVelocity.AddVelocity(new Vector3(0, yStrength, 0));
        }
    }
}
