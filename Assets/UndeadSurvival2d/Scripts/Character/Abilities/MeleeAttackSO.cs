

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
    public override void Awake(AbilityRunner runner)
    {
        base.Awake(runner);
        TriggerAbility(runner);
    }

    public override void TriggerAbility(AbilityRunner runner)
    {
        var ability = InstantiateAbility(runner);
    }

    public override void Run()
    {
        base.Run();
        Debug.Log("Casting Melee Attack!");
    }
}

