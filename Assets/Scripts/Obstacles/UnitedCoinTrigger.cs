using UnityEngine;
using UnityEngine.EventSystems;

public class UnitedCoinTrigger : MonoBehaviour {

    private IScoreTracker scoreTracker;

    // Use this for initialization
    void Start ()
    {
        scoreTracker = GameObject.FindGameObjectWithTag(Tags.GAMECONTROLLER.ToString()).GetComponent<IScoreTracker>();
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
