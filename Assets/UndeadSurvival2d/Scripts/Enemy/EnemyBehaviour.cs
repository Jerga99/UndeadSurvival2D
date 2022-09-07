using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Character;

namespace Eincode.UndeadSurvival2d.Enemy
{
    public class EnemyBehaviour : CharacterBehaviour
    {
        public string CollisionTag;

        private Damageable _closeTarget;

        new void Start()
        {
            base.Start();
        }

        private void Update()
        {
            if (_closeTarget)
            {
                _closeTarget.TakeDamage(10);
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
            }
        }

    }
}
