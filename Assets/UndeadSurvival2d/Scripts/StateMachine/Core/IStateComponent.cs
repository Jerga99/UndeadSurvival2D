

namespace Eincode.UndeadSurvival2d.StateMachine
{
    public interface IStateComponent
    {
        public void Awake(StateMachineCore stateMachine);
        public void OnEnter();
        public void OnExit();
    }
}

