
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;

namespace Eincode.UndeadSurvival2d.StateMachine
{
    public abstract class StateCondition : IStateComponent
    {
        public StateConditionSO originSO;

        public abstract void Awake(StateMachineCore stateMachine);
        public abstract void OnEnter();
        public abstract void OnExit();
    }
}


