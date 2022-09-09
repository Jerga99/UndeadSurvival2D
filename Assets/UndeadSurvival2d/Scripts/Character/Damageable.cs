using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Utils;

namespace Eincode.UndeadSurvival2d.Character
{
    public class Damageable : MonoBehaviour
    {
        public Color FlashDamageColor;
        public ParticleSystem ParticleHitEffect;

        [SerializeField]
        private IntValueSO _initialHealthSO;

        [SerializeField]
        [Header("Set only for Player")]
        private HealthSO _healthSO;

        private SpriteFlash _flashDamageEffect;

        private void Awake()
        {
            // Applies only for enemies
            if (_healthSO == null)
            {
                _healthSO = ScriptableObject.CreateInstance<HealthSO>();
            }

            _healthSO.CurrentHealth = _healthSO.MaxHealth = _initialHealthSO.InitialValue;

        }

        // Use this for initialization
        void Start()
        {
            _flashDamageEffect = GetComponentInChildren<SpriteFlash>();
        }

        public void TakeDamage(int damage)
        {
            _healthSO.InflictDamage(damage);

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


