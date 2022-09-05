using UnityEngine;


namespace Eincode.UndeadSurvival2d.StateMachine.Scriptable
{
    [CreateAssetMenu(fileName = "StateSO", menuName = "StateMachine/New State")]
    public class StateSO : ScriptableObject
    {
        [SerializeField]
        private StateActionSO[] _actionsSO;

        public string Name;

        public State GetState()
        {
            var state = new State();
            state.originSO = this;
            state.actions = _actionsSO == null ? new StateAction[0] : GetActions();
            return state;
        }

        private StateAction[] GetActions()
        {
            var actions = new StateAction[_actionsSO.Length];

            for (var i = 0; i < actions.Length; i++)
            {
                var action = _actionsSO[i].GetAction();
                actions[i] = action;
            }

            return actions;
        }
    }

}


