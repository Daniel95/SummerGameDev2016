using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShootTracker : MonoBehaviour {

    private BallVelocity ballVelocity;

    private bool islayingStill;

    [SerializeField]
    private Button ShootButton;
    [SerializeField]
    private Image AimPosition;
    private void Start()
    {
        islayingStill = true;
    }

    private void OnEnable()
    {
        ballVelocity = GameObject.FindGameObjectWithTag(Tags.BALL.ToString()).GetComponent<BallVelocity>();
        ballVelocity.layStill += SetInteractable;
    }

    private void OnDisable()
    {
        ballVelocity.layStill -= SetInteractable;
    }

    private void SetInteractable()
    {
        ShootButton.interactable = true;
        AimPosition.enabled = true;
    }

    public void SetInactive()
    {
        ShootButton.interactable = false;
        AimPosition.enabled = false;
    }

}
