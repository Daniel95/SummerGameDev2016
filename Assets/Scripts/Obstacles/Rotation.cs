using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public float RotationSpeed = 100f;
    private Vector3 _position;

	void Update ()
    {
       _position = GetComponent<Transform>().position;
        GetComponent<Transform>().RotateAround(_position, Vector3.up, RotationSpeed * Time.deltaTime);
    }
}
