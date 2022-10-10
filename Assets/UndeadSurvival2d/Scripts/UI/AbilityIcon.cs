using System;
using UnityEngine;
using UnityEngine.UI;

namespace Eincode.UndeadSurvival2d.UI
{
    public class AbilityIcon : MonoBehaviour
    {
        public Image CooldownImage;

        private Func<float> GetOverallCooldown;
        private Func<float> GetCurrentCooldown;

        private void Start()
        {
            enabled = false;
        }

        private void Update()
        {
            CooldownImage.fillAmount = GetCurrentCooldown() / GetOverallCooldown();
        }

        public void InitIcon(
            Func<float> getOverallCooldown,
            Func<float> getCurrentCooldown
        )
        {
            GetOverallCooldown = getOverallCooldown;
            GetCurrentCooldown = getCurrentCooldown;
            enabled = true;
        }

    }
}
