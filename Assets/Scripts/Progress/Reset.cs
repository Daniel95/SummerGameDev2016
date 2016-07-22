using UnityEngine;

public class Reset : MonoBehaviour {

    [SerializeField]
    private PlaySound playSound;

    private Vector3 oldPosition;

    private BallVelocity ballVelocity;

    private void Start()
    {
        oldPosition = transform.position;
        playSound = GetComponent<PlaySound>();
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
            playSound.Play();
            ballVelocity.ResetVelocity();
            transform.position = oldPosition; 
        }
    }
}
