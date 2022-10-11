
using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities.Action;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;

[CreateAssetMenu(
    fileName = "PlaySoundOnEnter",
    menuName = "Abilities/Modifiers/PlaySoundOnEnter"
)]
public class PlaySoundOnEnterSO : ActionModifierSO
{
    public override ActionModifier CreateActionModifier()
    {
        return new PlaySoundOnEnter();
    }
}

public class PlaySoundOnEnter : ActionModifier
{
    public override void Awake(AbilityAction action) { }

    public override void OnEnter(AbilityAction action)
    {
        action.PlaySoundEffect();
    }

    public override void Update(AbilityAction action) { }

}

