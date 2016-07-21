using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BoostPads : MonoBehaviour {
    [SerializeField]
    private float speedboost;

    void Start()
    {
        speedboost = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(Tags.BALL.ToString()))
        {
            ExecuteEvents.Execute<IBallVelocity>(collider.gameObject, null, (x, y) =>
            {
                x.MultiplyGivenAxes(new Vector3(speedboost,1,speedboost));
            }
            );
        }
    }
}
