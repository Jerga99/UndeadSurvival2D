

using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;
using System;

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
    private Action ActivateAbility;

    public override void Awake(AbilityRunner runner)
    {
        base.Awake(runner);
        TriggerAbility(runner);
    }

    public override void TriggerAbility(AbilityRunner runner)
    {
        var abilityGO = InstantiateAbility(runner);
        abilityGO.transform.parent = runner.transform;

        ActivateAbility = () => OnAbilityActiovation(abilityGO);
    }

    public override void Run()
    {
        base.Run();
        ActivateAbility();
    }

    private void OnAbilityActiovation(GameObject abilityGO)
    {
        abilityGO.SetActive(true);
    }
}

