using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Eincode.UndeadSurvival2d.UI
{
    public class SliderBar : MonoBehaviour
    {
        public Slider Slider;

        public void SetValue(float value, float maxValue)
        {
            Slider.value = value;
            Slider.maxValue = maxValue;
        }
    }
}
