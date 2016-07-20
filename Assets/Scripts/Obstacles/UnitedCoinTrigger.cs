using UnityEngine;

public class UnitedCoinTrigger : MonoBehaviour, IObstaclesBehaviour {

    private ScoreTracker scoreTracker;

    public void Interact()
    {
        scoreTracker.UnitedCoinCollected();
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        scoreTracker = GameObject.FindGameObjectWithTag(Tags.GAMECONTROLLER.ToString()).GetComponent<ScoreTracker>();
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag(Tags.BALL.ToString()))
        {
            Interact();
        }
    }
}
