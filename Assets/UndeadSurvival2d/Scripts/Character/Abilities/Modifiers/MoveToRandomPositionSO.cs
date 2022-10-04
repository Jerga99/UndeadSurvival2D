
using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities.Action;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;

[CreateAssetMenu(
    fileName = "MoveToRandomPosition",
    menuName = "Abilities/Modifiers/MoveToRandomPosition"
)]
public class MoveToRandomPositionSO : ActionModifierSO
{
    public override ActionModifier CreateActionModifier()
    {
        return new MoveToRandomPosition();
    }
}

public class MoveToRandomPosition : ActionModifier
{
    public override void Awake(AbilityAction action)
    {

    }

    public override void Update(AbilityAction action)
    {
        if (action.direction == Vector3.zero)
        {
            action.direction = Random.insideUnitCircle.normalized;
            action.transform.rotation = RotateAction(action);
        }

        var distanceDelta = Time.deltaTime * 2.0f;
        action.transform.position += action.direction * distanceDelta;
        action.currentDistance += distanceDelta;

        if (action.currentDistance > action.range)
        {
            action.DestroyAction();
        }

    }

    private Quaternion RotateAction(AbilityAction action)
    {
        var angle = Mathf.Atan2(action.direction.y, action.direction.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

