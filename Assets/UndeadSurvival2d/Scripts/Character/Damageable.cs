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

        [SerializeField]
        private IntValueSO _initialHealthSO;

        [SerializeField]
        [Header("Set only for Player")]
        private HealthSO _healthSO;

        private SpriteFlash _flashDamageEffect;
        private Animator _animator;
        private int _deadAnimationId;

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
            _animator = GetComponentInChildren<Animator>();
            _deadAnimationId = Animator.StringToHash("Dead");
            _flashDamageEffect = GetComponentInChildren<SpriteFlash>();
        }

        public void TakeDamage(int damage)
        {
            if (IsDead)
            {
                Debug.Log("I am death! Leave me alone! (:");
                return;
            }

            if (_healthSO.CurrentHealth - damage <= 0)
            {
                _animator.SetTrigger(_deadAnimationId);
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


