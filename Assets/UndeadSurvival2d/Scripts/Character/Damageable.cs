using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Utils;

namespace Eincode.UndeadSurvival2d.Character
{
    public class Damageable : MonoBehaviour
    {
        public Color FlashDamageColor;
        public ParticleSystem ParticleHitEffect;

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
            if (ParticleHitEffect != null)
            {
                ParticleHitEffect.Play();
            }

            if (_flashDamageEffect != null)
            {
                _flashDamageEffect.Flash(FlashDamageColor);
            }
        }
    }
}


