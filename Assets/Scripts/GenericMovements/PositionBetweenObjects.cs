using UnityEngine;

public class PositionBetweenObjects : MonoBehaviour {

    [SerializeField]
    private float vectorDistaneMultiplier = 0.5f;

    [SerializeField]
    private GameObject object1;

    [SerializeField]
    private GameObject object2;
	
	// Update is called once per frame
	void Update () {
        Vector3 vectorDistance = object2.transform.position - object1.transform.position;
        transform.position = object1.transform.position + (vectorDistance * vectorDistaneMultiplier);
	}
}
