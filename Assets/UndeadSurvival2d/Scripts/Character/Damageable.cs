using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Utils;

namespace Eincode.UndeadSurvival2d.Character
{
    public class Damageable : MonoBehaviour
    {

        private SpriteFlash _flashDamageEffect;

        // Use this for initialization
        void Start()
        {
            _flashDamageEffect = GetComponentInChildren<SpriteFlash>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(int damage)
        {
            Debug.Log("Taking Damage of: " + damage);

            if (_flashDamageEffect != null)
            {
                _flashDamageEffect.Flash();
            }
        }
    }
}


