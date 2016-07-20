using UnityEngine;
using UnityEngine.EventSystems;

public class UnitedCoinTrigger : MonoBehaviour {


    public void Interact()
    {
      
    }

    // Use this for initialization
    void Start () {
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag(Tags.BALL.ToString()))
        {
            ExecuteEvents.Execute<IScoreTracker>(collider.gameObject, null, (x, y) =>
            {
                x.UnitedCoinCollected();
            });
            Destroy(this.gameObject);
        }
    }
}
