using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private float speed = 2.0f;
    private float zoomSpeed = 2.0f;

    public float maxYLoc = 14.0f;
    public float minZLoc = -14.0f;


    public float minY = -25.0f;
    public float maxY = 75.0f;

    public float sensX = 100.0f;
    public float sensY = 7.3f;

    private float rotYMultiPlyer = 100.0f;

    float rotationY = 0.0f;

    public void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (transform.rotation.x >= maxY || transform.rotation.x <= minY)
            return;
        transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);
        rotationY += scroll * (sensY * rotYMultiPlyer) * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localEulerAngles = new Vector3(rotationY, 0, 0);
    }
}
