using UnityEngine;

public class Finish : MonoBehaviour {

    [SerializeField]
    private GameController gameController;

    private void OnTriggerEnter(Collider collision) {
        if (collision.CompareTag(Tags.BALL.ToString())) {
            gameController.Finish();
        }
    }
}
