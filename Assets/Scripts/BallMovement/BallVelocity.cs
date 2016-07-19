using UnityEngine;
using System.Collections;
using System;

public class BallVelocity : MonoBehaviour {

    [SerializeField]
    private float minVelocityValue = 0.1f;

    public Action layStill;

    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// add velocity to the target object.
    /// </summary>
    /// <param name="_velocity"></param>
    public void AddVelocity(Vector3 _velocity,  Vector3 _direction)
    {
        rb.velocity += _velocity;
    }

    /// <summary>
    /// starts the coroutine which checks if the ball is moving or not, fires off the layStill delegate when velocity is under the minimum.
    /// </summary>
    public void StartCheckVelocity() {
        StartCoroutine(CheckVelocity());
    }

    //checks if there is velocity or not
    IEnumerator CheckVelocity() {
        while (Vector3.Distance(rb.velocity, Vector3.zero) > minVelocityValue) {
            yield return new WaitForFixedUpdate();
        }

        rb.isKinematic = true;
        rb.isKinematic = false;

        if (layStill != null) {
            layStill();
        }
    }
}
