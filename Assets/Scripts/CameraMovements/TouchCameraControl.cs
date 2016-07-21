using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public float turnSpeed = 10.0f;
    public float perspectiveZoomSpeed = 0.5f;
    public float speed = 0.1f;
    public float distance = 5.0f;
    private bool isAiming = false;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Pinch();
        }
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            TurnCamera();
        }

        if (!CheckVisability(ball))
        {
            distance = minDistance;
        }

        // Clamp the field of view to make sure it's between 30 and 90.
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        Vector3 offset = (transform.position - ball.transform.position).normalized * distance;
        transform.position = Vector3.Lerp(transform.position, ball.transform.position + offset, Time.deltaTime);
        transform.LookAt(ball.transform);
    }

    private bool CheckVisability(GameObject Object)
    {
        RaycastHit hit;
        // Calculate Ray direction
        Vector3 direction =  ball.transform.position - transform.position ;
        Debug.DrawRay(transform.position, direction, Color.cyan);
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.transform.CompareTag(Tags.BALL.ToString()))
            {
                return true;
            }
        }
        return false;
    }

    private void TurnCamera()
    {
        // Get movement of the finger since last frame
        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        transform.RotateAround(ball.transform.position, Vector3.down, ((Time.deltaTime * touchDeltaPosition.x) * turnSpeed));
        transform.RotateAround(ball.transform.position, Vector3.left, ((Time.deltaTime * touchDeltaPosition.y) * turnSpeed));
    }

    private void Pinch()
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

}