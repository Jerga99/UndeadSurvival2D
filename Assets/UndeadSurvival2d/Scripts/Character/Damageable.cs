using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Utils;
using Eincode.UndeadSurvival2d.Manager;

namespace Eincode.UndeadSurvival2d.Character
{
    public class Damageable : MonoBehaviour
    {
        public Color FlashDamageColor;
        public ParticleSystem ParticleHitEffect;

        public bool IsDead => _healthSO.CurrentHealth <= 0;

        public int Health => _healthSO.CurrentHealth;
        public int MaxHealth => _healthSO.MaxHealth;

        public float HealthPercentage => (float)Health / (float)MaxHealth * 100f;

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
            if (IsDead)
            {
                return;
            }

            _healthSO.InflictDamage(damage);

            UIManager.Instance.ShowDamage(damage, transform);

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


