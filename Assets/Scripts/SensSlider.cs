using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensSlider : MonoBehaviour
{
    [SerializeField] public Slider sslider;
    public static float sliderValue = 100;

    public void Update()
    {
        sliderValue = sslider.value;
    }
}
