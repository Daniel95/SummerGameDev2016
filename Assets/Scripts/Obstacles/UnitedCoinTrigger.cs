using UnityEngine;

public class UnitedCoinTrigger : MonoBehaviour, IObstaclesBehaviour {

    private ScoreTracker scoreCalc;

    public void Interact()
    {
        scoreCalc.UnitedCoinCollected();
        Debug.Log("Hit Test");
        //Destroy(this);
    }

    // Use this for initialization
    void Start () {
        scoreCalc = GameObject.FindGameObjectWithTag(Tags.GAMECONTROLLER.ToString()).GetComponent<ScoreTracker>();
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag(Tags.BALL.ToString()))
        {
            Interact();
        }
    }
}
