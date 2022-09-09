using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Eincode.UndeadSurvival2d.UI
{
    public class SliderBar : MonoBehaviour
    {
        public Slider Slider;

        void Start()
        {
            SetValue(100, 100);
        }

        public void SetValue(float value, float maxValue)
        {
            Slider.value = value;
            Slider.maxValue = maxValue;
        }
    }
}
