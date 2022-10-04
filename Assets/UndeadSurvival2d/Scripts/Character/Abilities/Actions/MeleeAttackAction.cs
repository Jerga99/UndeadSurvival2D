

using UnityEngine;
using Eincode.UndeadSurvival2d.Manager;

public class MeleeAttackAction : CollisionAction
{
    private SpriteRenderer _sprite;

    protected override void Start()
    {
        base.Start();
        _sprite = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        _sprite.flipX = GameManager.Instance.GetPlayer().GetFlipX();
    }
}

