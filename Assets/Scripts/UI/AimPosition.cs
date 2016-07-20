using UnityEngine;
using UnityEngine.UI;

public class AimPosition : MonoBehaviour {

    [SerializeField]
    private int maxYStrength = 20;

    [SerializeField]
    private int minYStrength = -10;

    [SerializeField]
    private int maxXEffectStrength = 20;

    [SerializeField]
    private int minXEffectStrength = -20;

    private ScrollRect scrollRect;

	// Use this for initialization
	void Start () {
        scrollRect = GetComponent<ScrollRect>();
    }

    public ScrollRect ScrollRect {
        get { return scrollRect; }
    }

    /// <summary>
    /// returns the ball Y strength
    /// </summary>
    /// <returns></returns>
    public float getBallYStrength() {
        return minYStrength + Mathf.Abs(maxYStrength - minYStrength) * scrollRect.verticalNormalizedPosition;
    }

    /// <summary>
    /// returns the ball x effect strength
    /// </summary>
    /// <returns></returns>
    public float getBallXEffectStrength()
    {
        return minXEffectStrength + Mathf.Abs(maxXEffectStrength - minXEffectStrength) * scrollRect.horizontalNormalizedPosition;
    }
}
