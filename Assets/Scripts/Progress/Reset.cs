using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    private Vector3 oldPosition;

    private BallVelocity ballVelocity;

    private void Start()
    {
        oldPosition = transform.position;
    }

    private void OnEnable()
    {
        ballVelocity = GetComponent<BallVelocity>();
        ballVelocity.layStill += SetPosition;
    }

    private void OnDisable()
    {
        ballVelocity.layStill -= SetPosition;
    }

    private void SetPosition()
    {
        oldPosition = transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(Tags.RESET.ToString()))
        {
            ballVelocity.ResetVelocity();
            transform.position = oldPosition; 
        }
    }
}
