using UnityEngine;

public class UnitedCoinTrigger : MonoBehaviour {

    private ScoreTracker scoreTracker;

    public void Interact()
    {
      
    }

    // Use this for initialization
    void Start () {
        scoreTracker = GameObject.FindGameObjectWithTag(Tags.GAMECONTROLLER.ToString()).GetComponent<ScoreTracker>();
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag(Tags.BALL.ToString()))
        {
            scoreTracker.UnitedCoinCollected();
            Destroy(this.gameObject);
        }
    }
}
