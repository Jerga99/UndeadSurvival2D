

using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;
using System;
using Eincode.UndeadSurvival2d.Abilities.Action;

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
    private Transform _source;

    public override void Awake(AbilityRunner runner)
    {
        base.Awake(runner);
        _source = runner.transform;
        TriggerAbility();
    }

    public override void TriggerAbility()
    {
        var abilityGO = InstantiateAbility(out AbilityAction action);

        abilityGO.transform.parent = _source;
        abilityGO.transform.localPosition = Vector3.zero;

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

