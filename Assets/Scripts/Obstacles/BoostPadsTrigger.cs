using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BoostPadsTrigger : MonoBehaviour {

    [SerializeField]
    private float speedboost;

    private PlaySound playSound;

    void Start()
    {
        playSound = GetComponent<PlaySound>();
        speedboost = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(Tags.BALL.ToString()))
        {
            playSound.Play();

            ExecuteEvents.Execute<IBallVelocity>(collider.gameObject, null, (x, y) =>
            {
                x.MultiplyVelocity(speedboost);
            });
        }
    }
}
