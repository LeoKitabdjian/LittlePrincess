using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    

    public void setFear(float fear)
    {
        slider.value = fear;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
