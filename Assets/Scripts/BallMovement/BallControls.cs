using UnityEngine;
using System.Collections;

public class BallControls : MonoBehaviour {

    [SerializeField]
    private GetSliderValue strengthSlider;

    [SerializeField]
    private AimPosition aimPosition;

    [SerializeField]
    private GameObject camera;
    
    private BallVelocity ballVelocity;

    private PlaySound playSound;

    private bool canShoot = true;

    private void Awake() {
        playSound = GetComponent<PlaySound>();
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
            playSound.Play();

            ballVelocity.ShootFromPosition(strengthSlider.Slider.value, aimPosition.getBallYStrength(), camera.transform.position);
            ballVelocity.StartBallEffect(aimPosition.getBallXEffectStrength(), strengthSlider.Slider.value, camera.transform);
            aimPosition.ResetAimPosition();
            ballVelocity.StartCheckVelocity();

            canShoot = false;
        }
    }
}
