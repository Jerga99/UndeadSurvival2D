

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
    public float Range;

    protected override Ability CreateAbility()
    {
        return new ProjectileAbility();
    }
}

public class ProjectileAbility : Ability
{
    public ProjectileAbilitySO OriginSO => (ProjectileAbilitySO)originSO;
    private Transform _source;

    public override void Awake(AbilityRunner runner)
    {
        base.Awake(runner);
        _source = runner.transform;
    }

    public override void TriggerAbility()
    {
        var abilityGO = InstantiateAbility(out AbilityAction action);
        abilityGO.transform.position = _source.position;

        action.range = OriginSO.Range;
    }

    public override void Run()
    {
        base.Run();
        TriggerAbility();
    }
}

