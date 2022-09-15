

using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;

[CreateAssetMenu(
    fileName = "MeleeAttackSO",
    menuName = "Abilities/MeleeAttack"
)]
public class MeleeAttackSO : AbilitySO
{
    protected override Ability CreateAbility()
    {
        return new MeleeAttack();
    }
}

public class MeleeAttack : Ability
{
    private GameObject _abilityGO;

    public override void Awake(AbilityRunner runner)
    {
        base.Awake(runner);
        TriggerAbility(runner);
    }

    public override void TriggerAbility(AbilityRunner runner)
    {
        _abilityGO = InstantiateAbility(runner);
        _abilityGO.transform.parent = runner.transform;
    }

    public override void Run()
    {
        base.Run();
        _abilityGO.SetActive(true);
    }
}

