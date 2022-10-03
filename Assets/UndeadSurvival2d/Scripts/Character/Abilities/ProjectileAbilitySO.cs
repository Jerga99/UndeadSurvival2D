

using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;
using Eincode.UndeadSurvival2d.Abilities.Action;

[CreateAssetMenu(
    fileName = "ProjectileAbilitySO",
    menuName = "Abilities/ProjectileAbility"
)]
public class ProjectileAbilitySO : AbilitySO
{
    protected override Ability CreateAbility()
    {
        return new ProjectileAbility();
    }
}

public class ProjectileAbility : Ability
{
    public override void Awake(AbilityRunner runner)
    {
        base.Awake(runner);
    }

    public override void TriggerAbility()
    {
        var abilityGO = InstantiateAbility(out AbilityAction action);
    }

    public override void Run()
    {
        base.Run();
        Debug.Log("Casting Projectile!");
        TriggerAbility();
    }
}

