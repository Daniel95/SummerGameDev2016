using UnityEngine;
using System.Collections;

public class BallControls : MonoBehaviour {

    [SerializeField]
    private string inputName = "space";

    [SerializeField]
    private GetSliderValue strengthSlider;

    [SerializeField]
    private GetSliderValue heightSlider;

    private BallVelocity ballVelocity;

    private void Awake() {
        ballVelocity = GetComponent<BallVelocity>();
        StartCoroutine(AwaitInput());
    }

    private void OnEnable() {
        ballVelocity.layStill += StartAwaitInput;
    }

    private void OnDisable() {
        ballVelocity.layStill -= StartAwaitInput;
    }

    private void StartAwaitInput() {
        StartCoroutine(AwaitInput());
    }

    IEnumerator AwaitInput() {
        while (!Input.GetKeyDown(inputName)) {
            yield return new WaitForFixedUpdate();
        }

        ballVelocity.AddVelocity(new Vector3(strengthSlider.Slider.value, heightSlider.Slider.value, 0), Vector3.zero);
        ballVelocity.StartCheckVelocity();
    }
}
