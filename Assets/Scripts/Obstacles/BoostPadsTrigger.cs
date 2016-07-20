using UnityEngine;
using System.Collections;

public class BoostPads : MonoBehaviour {
    [SerializeField]
    private float speedboost;

    [SerializeField]
    private GameObject script;

    void Start()
    {
        speedboost = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(Tags.BALL.ToString()))
        {

        }
    }
}
