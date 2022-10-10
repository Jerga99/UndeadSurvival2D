
using UnityEngine;

namespace Eincode.UndeadSurvival2d.UI
{
    public class HealthBar : SliderBar
    {
        public Vector3 Offset;
        public Transform followTo;

        [SerializeField]
        private HealthSO _healthSO;

        private void Update()
        {
            SetValue(_healthSO.CurrentHealth, _healthSO.MaxHealth);

            transform.position = followTo.position + Offset;
        }
    }
}
