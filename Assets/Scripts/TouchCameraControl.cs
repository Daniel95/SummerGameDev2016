using UnityEngine;
using System.Collections;

public class TouchCameraControl : MonoBehaviour
{
    [SerializeField]
    private float minFieldOfView = 0.1f;
    [SerializeField]
    private float maxFieldOfView = 179.9f;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject ball;

    public float perspectiveZoomSpeed = 0.5f;
    public float speed = 0.1f;

    int nbTouches = Input.touchCount;



    void Update()
    {
        // If there are two touches on the device...
        //if (Input.touchCount >= 2)
        //{
        //    print("multitouch");
        //    // Store both touches.
        //    Touch touchZero = Input.GetTouch(0);
        //    Touch touchOne = Input.GetTouch(1);

        //    // Find the position in the previous frame of each touch.
        //    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    // Find the magnitude of the vector (the distance) between the touches in each frame.
        //    float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

        //    // Find the difference in the distances between each frame.
        //    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

        //    // Otherwise change the field of view based on the change in distance between the touches.
        //    _camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

        //    // Clamp the field of view to make sure it's between 0 and 180.
        //    _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, minFieldOfView, maxFieldOfView);
        //}
        //else
        //{
            //single touch
            if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.touchCount <= 1)
            {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                print("single touch + movement");
                // Move object across XY plane
               // transform.Translate(-touchDeltaPosition.x * speed, 0, 0);
                transform.RotateAround(ball.transform.position, Vector3.up, touchDeltaPosition.x);
            }
        //    if (Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount <= 1)
        //    {
        //        Touch touch = Input.GetTouch(0);

        //        Ray screenRay = Camera.main.ScreenPointToRay(touch.position);

        //        RaycastHit hit;
        //        if (Physics.Raycast(screenRay, out hit))
        //        {
        //            print("single touch + tap");
        //            //handleTap(hit.collider.gameObject);
        //        }
        //    }

        //}
    }
}