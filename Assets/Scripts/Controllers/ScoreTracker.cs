﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour, IScoreTracker
{
    private BallVelocity ballVelocity;
    [SerializeField]
    private Text hitsTextField;
    [SerializeField]
    private Image unitedCoinsImage;

    private const string defaulthitsText = "Aantal Schoten: ";

    private int shotCount;
    private bool islayingStill;

    private void Start()
    {
        shotCount = 0;
        islayingStill = true;
    }
    private void OnEnable()
    {
        ballVelocity = GameObject.FindGameObjectWithTag(Tags.BALL.ToString()).GetComponent<BallVelocity>();
        ballVelocity.layStill += SetIsLayingStill;
    }

    private void OnDisable()
    {
        ballVelocity.layStill -= SetIsLayingStill;
    }

    private void SetIsLayingStill()
    {
        islayingStill = true;
    }

    public void UnitedCoinCollected()
    {
        unitedCoinsImage.color = new Color(1, 1, 1, 1);
    }

    public void IncreaseShotCount()
    {
        if(islayingStill)
        {
            string extraText;
            shotCount++;

            if(shotCount < 10)
                extraText = "0" + shotCount;
            else
                extraText = shotCount.ToString();

            hitsTextField.text = defaulthitsText + extraText;
            islayingStill = false;
        }
    }
}
