using UnityEngine;


namespace Eincode.UndeadSurvival2d.StateMachine.Scriptable
{
    [CreateAssetMenu(fileName = "StateSO", menuName = "StateMachine/New State")]
    public class StateSO : ScriptableObject
    {
        public string Name;

        public State GetState()
        {
            var state = new State();
            state.originSO = this;

            return state;
        }
    }

}


