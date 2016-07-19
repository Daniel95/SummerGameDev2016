using UnityEngine;
using System.Collections;

public class TouchCameraControl : MonoBehaviour
{
    [SerializeField]
    private float minDistance = 3.0f;
    [SerializeField]
    private float maxDistance = 10.0f;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject ball;

    public float perspectiveZoomSpeed = 0.5f;
    public float speed = 0.1f;
    public float distance = 10.0f;

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Otherwise change the field of view based on the change in distance between the touches.
            distance += deltaMagnitudeDiff * perspectiveZoomSpeed;
        }
        //single touch
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.RotateAround(ball.transform.position, Vector3.down, ((Time.deltaTime * touchDeltaPosition.x) * 2.5f));
            transform.RotateAround(ball.transform.position, Vector3.left, ((Time.deltaTime * touchDeltaPosition.y) * 2.5f));
        }
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Ray screenRay = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(screenRay, out hit))
            {
              
            }
        }
        // Clamp the field of view to make sure it's between 30 and 90.
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Vector3 offset = (transform.position - ball.transform.position).normalized * distance;
        transform.position = Vector3.Lerp(transform.position, ball.transform.position + offset, Time.deltaTime);
        transform.LookAt(ball.transform);
    }
}