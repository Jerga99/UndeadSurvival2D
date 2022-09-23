


using UnityEngine;

namespace Eincode.UndeadSurvival2d.StateMachine.Scriptable
{
    public abstract class StateConditionSO : ScriptableObject
    {
        public StateCondition GetCondition(StateMachineCore stateMachine)
        {
            var condition = CreateCondition(stateMachine);
            condition.originSO = this;
            condition.Awake(stateMachine);
            Debug.Log("Getting Condition!");
            return condition;
        }

        public abstract StateCondition CreateCondition(StateMachineCore stateMachine);

    }
}


