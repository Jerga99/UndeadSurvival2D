
using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities.Action;
using Eincode.UndeadSurvival2d.Character;

public class CollisionAction : AbilityAction
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((abilitySO.CollideWith.value & 1 << collision.transform.gameObject.layer) > 0)
        {
            if (collision.TryGetComponent<Damageable>(out var damageable))
            {
                damageable.TakeDamage(abilitySO.Damage);

                if (abilitySO.DestroyOnCollision)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

