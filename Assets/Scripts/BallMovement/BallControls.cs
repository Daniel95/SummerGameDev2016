using UnityEngine;
using System.Collections;

public class BallControls : MonoBehaviour {

    [SerializeField]
    private GetSliderValue strengthSlider;

    [SerializeField]
    private AimPosition aimPosition;

    [SerializeField]
    private ScoreTracker scoreTracker;

    [SerializeField]
    private GameObject camera;

    private BallVelocity ballVelocity;

    private bool canShoot = true;

    private void Awake() {
        ballVelocity = GetComponent<BallVelocity>();
    }

    private void OnEnable() {
        ballVelocity.layStill += StartAwaitInput;
    }

    private void OnDisable() {
        ballVelocity.layStill -= StartAwaitInput;
    }

    private void StartAwaitInput() {
        canShoot = true;
    }

    /// <summary>
    /// activates the required functions to shoot the ball, and checks if we can currently shoot
    /// </summary>
    public void Shoot() {
        if (canShoot) {
            ballVelocity.ShootFromPosition(strengthSlider.Slider.value, aimPosition.getBallYStrength(), camera.transform.position);
            ballVelocity.StartBallEffect(aimPosition.getBallXEffectStrength(), strengthSlider.Slider.value, camera.transform);
            aimPosition.ResetAimPosition();
            ballVelocity.StartCheckVelocity();

            canShoot = false;
        }
    }
}
