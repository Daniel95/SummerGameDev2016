using UnityEngine;

public class PointsBehaviour : MonoBehaviour, IObstaclesBehaviour {

    public GameObject ballObject;
    public GameObject scoreCalc;

    public void Interact()
    {
        Debug.Log("Hit Test");
        //Destroy(this);
    }

    // Use this for initialization
    void Start () {
        scoreCalc = GameObject.FindGameObjectWithTag(Tags.GAMECONTROLLER.ToString());
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag(Tags.BALL.ToString()))
        {
            Interact();
        }
    }
}
