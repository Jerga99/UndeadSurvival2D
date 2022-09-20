using UnityEngine;
using Eincode.UndeadSurvival2d.Character;
using Eincode.UndeadSurvival2d.Manager;




namespace Eincode.UndeadSurvival2d.Abilities.Action
{
    public class AbilityAction : MonoBehaviour
    {
        public LayerMask CollideWith;

        private SpriteRenderer _sprite;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            _sprite.flipX = GameManager.Instance.GetPlayer().GetFlipX();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((CollideWith.value & 1 << collision.transform.gameObject.layer) > 0)
            {
                if (collision.TryGetComponent<Damageable>(out var damageable))
                {
                    damageable.TakeDamage(30);
                }
            }
        }
    }
}


