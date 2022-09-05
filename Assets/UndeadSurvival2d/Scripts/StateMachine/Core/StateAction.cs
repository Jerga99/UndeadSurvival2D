

using Eincode.UndeadSurvival2d.StateMachine.Scriptable;

namespace Eincode.UndeadSurvival2d.StateMachine
{
    abstract public class StateAction
    {
        public StateActionSO originSO;

        public void OnEnter() { }
        public void OnExit() { }
        public void OnUpdate() { }
    }
}
