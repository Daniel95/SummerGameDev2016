using UnityEngine;
using System.Collections;
using System;

public class BallVelocity : MonoBehaviour, IBallVelocity {

    [SerializeField]
    private float minVelocityValue = 0.5f;

    [SerializeField]
    private float effectMultiplierStart = 0.25f;

    [SerializeField]
    private float effectMultiplierOverTime = 0.95f;

    public Action layStill;

    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// add velocity to the target object.
    /// </summary>
    /// <param name="_velocity"></param>
    public void ShootFromPosition(float _strength, float _height, Vector3 _shootPosition)
    {
        Vector3 angle = getAngle(_shootPosition);

        if (_height < 1) {
            _height = 1;
        }

        rb.velocity += new Vector3((_strength / Mathf.Abs(_height)) * angle.x, (_height / 10) * _strength, (_strength / Mathf.Abs(_height)) * angle.z);
    }

    /// <summary>
    /// Starts the coroutine that gives the ball an effect.
    /// </summary>
    public void StartBallEffect(float _xEffectValue, float _shootStrength, Transform _shooter)
    {
        StartCoroutine(BallEffect(_xEffectValue, _shootStrength, _shooter));
    }

    //gives the ball an effect
    IEnumerator BallEffect(float _xEffectValue, float _shootStrength, Transform _shooter)
    {
        Vector3 effectVector = getAngle(_shooter.position - _shooter.right * _xEffectValue) * (_shootStrength * effectMultiplierStart);

        while (CheckMinumumVectorSize(effectVector))
        {
            rb.velocity += effectVector;
            effectVector *= effectMultiplierOverTime;

            yield return new WaitForFixedUpdate();
        }
    }

    private Vector3 getAngle(Vector3 _othersPosition) {
        Vector3 vectorToShooter = transform.position - _othersPosition;

        Vector3 AbsoluteVectorToShooter = new Vector3(Mathf.Abs(_othersPosition.x - transform.position.x), Mathf.Abs(_othersPosition.y - transform.position.y), Math.Abs(_othersPosition.z - transform.position.z));

        float totalVector = AbsoluteVectorToShooter.x + AbsoluteVectorToShooter.z;

        float xDir = (AbsoluteVectorToShooter.x / totalVector);
        if (vectorToShooter.x < 0)
            xDir *= -1;

        float zDir = (AbsoluteVectorToShooter.z / totalVector);
        if (vectorToShooter.z < 0)
            zDir *= -1;

        return new Vector3(xDir, 0, zDir);
    }

    /// <summary>
    /// starts the coroutine which checks if the ball is moving or not, fires off the layStill delegate when velocity is under the minimum.
    /// </summary>
    public void StartCheckVelocity() {
        StartCoroutine(CheckVelocity());
    }

    //checks if there is velocity or not
    IEnumerator CheckVelocity() {
        while (CheckMinumumVectorSize(rb.velocity)) {
            yield return new WaitForFixedUpdate();
        }

        rb.isKinematic = true;
        rb.isKinematic = false;

        if (layStill != null) {
            layStill();
        }
    }

    private bool CheckMinumumVectorSize(Vector3 _vector)
    {
        if (Vector3.Distance(_vector, Vector3.zero) > minVelocityValue)
            return true;
        else
            return false;
    }

    public void MultiplyVelocity(float _multiplier) {
        rb.velocity *= _multiplier;
    }
}
