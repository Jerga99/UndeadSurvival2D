

using UnityEngine;
using Eincode.UndeadSurvival2d.StateMachine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;
using Eincode.UndeadSurvival2d.Character;

[CreateAssetMenu(
    fileName = "HealthIsEqualOrLessSO",
    menuName = "StateMachine/Enemy/Conditions/Health is Equal or Less"
)]
public class HealthIsEqualOrLessSO : StateConditionSO
{
    public int HealthPercentage;

    public override StateCondition CreateCondition(StateMachineCore stateMachine)
    {
        return new HealthIsEqualOrLess();
    }
}

public class HealthIsEqualOrLess : StateCondition
{
    public HealthIsEqualOrLessSO OriginSO => (HealthIsEqualOrLessSO)originSO;

    private Damageable _damageable;

    public override void Awake(StateMachineCore stateMachine)
    {
        _damageable = stateMachine.GetComponent<Damageable>();
    }

    public override void OnEnter() { }

    public override void OnExit() { }

    protected override bool Statement()
    {
        return _damageable.HealthPercentage <= OriginSO.HealthPercentage;
    }
}

