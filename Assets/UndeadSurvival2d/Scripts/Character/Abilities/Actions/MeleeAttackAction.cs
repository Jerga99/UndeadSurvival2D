

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

        var playerDirection = GameManager.Instance.GetPlayer().GetPlayerDirection();
        var scale = _sprite.transform.localScale;

        if (playerDirection != GetDirection())
        {
            _sprite.transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }

    }

    public int GetDirection()
    {
        if (_sprite.transform.localScale.x >= 0)
        {
            // Right
            return +1;
        }
        else
        {
            // Left
            return -1;
        }
    }
}

