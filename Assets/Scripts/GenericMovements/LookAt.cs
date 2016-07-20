using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

    [SerializeField]
    private Transform transformToLookAt;
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(transformToLookAt.position);
	}
}
