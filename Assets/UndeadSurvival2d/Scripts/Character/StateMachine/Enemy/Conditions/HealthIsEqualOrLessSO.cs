

using UnityEngine;
using Eincode.UndeadSurvival2d.StateMachine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;

[CreateAssetMenu(
    fileName = "HealthIsEqualOrLessSO",
    menuName = "StateMachine/Enemy/Conditions/Health is Equal or Less"
)]
public class HealthIsEqualOrLessSO : StateConditionSO
{
    public override StateCondition CreateCondition(StateMachineCore stateMachine)
    {
        return new HealthIsEqualOrLess();
    }
}

public class HealthIsEqualOrLess : StateCondition
{
    public override void Awake(StateMachineCore stateMachine) { }

    public override void OnEnter() { }

    public override void OnExit() { }

    protected override bool Statement()
    {
        return false;
    }
}

