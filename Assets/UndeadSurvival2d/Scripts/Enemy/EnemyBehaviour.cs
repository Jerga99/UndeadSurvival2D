using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Character;

namespace Eincode.UndeadSurvival2d.Enemy
{
    public class EnemyBehaviour : CharacterBehaviour
    {
        public string CollisionTag;
        public float DamageInterval;

        private Damageable _closeTarget;
        private float _damageTimer;

        new void Start()
        {
            base.Start();
            _damageTimer = DamageInterval;
        }

        private void Update()
        {
            if (_closeTarget)
            {
                _damageTimer += Time.deltaTime;

                if (_damageTimer >= DamageInterval)
                {
                    _closeTarget.TakeDamage(10);
                    _damageTimer = 0;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(CollisionTag))
            {
                if (collision.gameObject.TryGetComponent<Damageable>(out var damageable))
                {
                    _closeTarget = damageable;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(CollisionTag))
            {
                _closeTarget = null;
                _damageTimer = DamageInterval;
            }
        }

    }
}
