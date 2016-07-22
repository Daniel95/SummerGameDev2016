using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour, IScoreTracker
{
    private BallVelocity ballVelocity;
    [SerializeField]
    private Text hitsTextField;
    [SerializeField]
    private Image unitedCoinsImage;

    [SerializeField]
    private Font textFont;

    private const string defaulthitsText = "Aantal Schoten: ";

    public bool coinCollected;
    public int shotCount;
    private bool islayingStill;

    private void Start()
    {
        hitsTextField.font = textFont;
        hitsTextField.text = defaulthitsText + "00";
        unitedCoinsImage.color = new Color(1, 1, 1, 0.2f);
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
