using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BoostPadsTrigger : MonoBehaviour {

    [SerializeField]
    private float speedMultiplier;

    private PlaySound playSound;

    void Start()
    {
        playSound = GetComponent<PlaySound>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(Tags.BALL.ToString()))
        {
            playSound.Play();

            ExecuteEvents.Execute<IBallVelocity>(collider.gameObject, null, (x, y) =>
            {
                x.MultiplyGivenAxes(new Vector3(speedMultiplier, 1, speedMultiplier));
            });
        }
    }
}
