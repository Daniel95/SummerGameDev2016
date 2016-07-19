using UnityEngine;
using UnityEngine.UI;
using System;

public class GetSliderValue : MonoBehaviour {

    private Action<float> changedSliderValue;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        if (changedSliderValue != null)
            changedSliderValue(slider.value);

        slider.onValueChanged.AddListener((lambda) => {
            if(changedSliderValue != null)
                changedSliderValue(slider.value);
        });
    }

    /// <summary>
    /// the slider we use to set the amount of the velocity we add.
    /// </summary>
    public Slider Slider {
        get { return slider; }
    }
}
