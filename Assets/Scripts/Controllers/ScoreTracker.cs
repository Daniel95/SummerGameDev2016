using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    [SerializeField]
    private Text hitsTextField;
    [SerializeField]
    private Image unitedCoinsImage;

    [SerializeField]
    private Sprite unitedCoinCompleted;
    [SerializeField]
    private Sprite unitedCoinsEmpty;

    private int shotCount;

    void Start()
    {
        //set the default image
        //unitedCoinsEmpty = 
        shotCount = 0;
    }

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
