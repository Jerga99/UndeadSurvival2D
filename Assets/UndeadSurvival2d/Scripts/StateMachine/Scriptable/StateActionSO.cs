
using UnityEngine;

namespace Eincode.UndeadSurvival2d.StateMachine.Scriptable
{
    abstract public class StateActionSO : ScriptableObject
    {
        public StateAction GetAction(StateMachineCore stateMachine)
        {
            var action = CreateAction();
            action.Awake(stateMachine);
            action.originSO = this;
            return action;
        }

        public abstract StateAction CreateAction();
    }
}
