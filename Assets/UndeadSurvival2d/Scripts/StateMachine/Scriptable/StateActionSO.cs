
using UnityEngine;

namespace Eincode.UndeadSurvival2d.StateMachine.Scriptable
{
    abstract public class StateActionSO : ScriptableObject
    {
        public StateAction GetAction()
        {
            var action = CreateAction();
            action.originSO = this;
            return action;
        }

        public abstract StateAction CreateAction();
    }
}
