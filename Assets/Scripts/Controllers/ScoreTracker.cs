using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour, IScoreTracker
{

    [SerializeField]
    private Text hitsTextField;
    [SerializeField]
    private Image unitedCoinsImage;

    [SerializeField]
    private Sprite unitedCoinCompleted;
    [SerializeField]
    private Sprite unitedCoinsEmpty;

    private int shotCount = 0;

    public void UnitedCoinCollected()
    {
        unitedCoinsImage.sprite = unitedCoinCompleted;
    }

    public void IncreaseShotCount()
    {
        shotCount++;
        hitsTextField.text = shotCount.ToString();
    }
}
