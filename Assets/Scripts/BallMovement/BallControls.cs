using UnityEngine;
using System.Collections;

public class BallControls : MonoBehaviour {

    [SerializeField]
    private GetSliderValue strengthSlider;

    [SerializeField]
    private GetSliderValue heightSlider;

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

    public void Shoot() {
        if (canShoot) {
            ballVelocity.ShootFromPosition(strengthSlider.Slider.value, heightSlider.Slider.value, camera.transform.position);
            ballVelocity.StartCheckVelocity();

            canShoot = false;
        }
    }
}
