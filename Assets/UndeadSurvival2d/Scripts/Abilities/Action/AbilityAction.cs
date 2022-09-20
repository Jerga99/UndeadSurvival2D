using Eincode.UndeadSurvival2d.Character;
using UnityEngine;




namespace Eincode.UndeadSurvival2d.Abilities.Action
{
    public class AbilityAction : MonoBehaviour
    {
        public LayerMask CollideWith;

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


