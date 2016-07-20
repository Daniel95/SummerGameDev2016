using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    [SerializeField]
    private Text Text;

    private int shotCount = 0;

    public void UnitedCoinCollected()
    {
        Text.text = "POINTS";
    }

    public void IncreaseShotCount()
    {
        shotCount++;
        Text.text = shotCount.ToString();
    }
}
