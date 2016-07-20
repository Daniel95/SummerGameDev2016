using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AimPosition : MonoBehaviour {

    private ScrollRect scrollRect;

	// Use this for initialization
	void Start () {
        scrollRect = GetComponent<ScrollRect>();
    }

    public ScrollRect ScrollRect {
        get { return scrollRect; }
    }
}
