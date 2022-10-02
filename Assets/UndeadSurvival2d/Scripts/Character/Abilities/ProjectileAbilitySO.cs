

using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;

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

    public override void TriggerAbility(AbilityRunner runner)
    {
        var abilityGO = InstantiateAbility(runner);
        abilityGO.transform.parent = runner.transform;
    }

    public override void Run()
    {
        base.Run();
        Debug.Log("Casting Projectile!");
    }
}

