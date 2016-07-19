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
    public void ShootFromPosition(float _distance, float _height, Vector3 _shootPosition)
    {
        Vector3 vectorToShooter = transform.position - _shootPosition;

        Vector3 AbsoluteVectorToShooter = new Vector3(Mathf.Abs(_shootPosition.x - transform.position.x), Mathf.Abs(_shootPosition.y - transform.position.y), Math.Abs(_shootPosition.z - transform.position.z));

        float totalVector = AbsoluteVectorToShooter.x + AbsoluteVectorToShooter.z;

        float xDir = (AbsoluteVectorToShooter.x / totalVector);
        if (vectorToShooter.x < 0)
            xDir *= -1;

        float zDir = (AbsoluteVectorToShooter.z / totalVector);
        if (vectorToShooter.z < 0)
            zDir *= -1;

        rb.velocity += new Vector3(_distance * xDir, _height, _distance *  zDir);
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
