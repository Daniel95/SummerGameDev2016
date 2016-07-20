using UnityEngine;
using System.Collections;

public class BoostPads : MonoBehaviour {
    [SerializeField]
    private float speedboost;

    [SerializeField]
    private GameObject script;


    private IBallVelocity ballVelocity;

    void Start()
    {
        speedboost = 0;
        ballVelocity = GameObject.FindGameObjectWithTag(Tags.BALL.ToString()).GetComponent<IBallVelocity>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(Tags.BALL.ToString()))
        {
            ballVelocity.MultiplyVelocity(speedboost);
        }
    }
}
