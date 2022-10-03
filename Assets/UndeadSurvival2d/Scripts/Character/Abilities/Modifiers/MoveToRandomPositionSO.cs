
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
        Debug.Log("Calling MoveToRandomPosition action!");
    }
}

