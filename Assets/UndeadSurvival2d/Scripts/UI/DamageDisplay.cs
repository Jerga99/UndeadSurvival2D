using UnityEngine;
using TMPro;

namespace Eincode.UndeadSurvival2d.UI
{
    public class DamageDisplay : MonoBehaviour
    {
        public TextMeshProUGUI DamageText;

        private Transform _target;
        private RectTransform _canvas;


        public void ShowDamage(
            int damage,
            Transform target,
            RectTransform canvas
        )
        {
            _canvas = canvas;
            _target = target;
            DamageText.text = damage.ToString();
            gameObject.SetActive(true);
        }

    }
}


