

using UnityEngine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;

namespace Eincode.UndeadSurvival2d.StateMachine
{
    public class State
    {
        public StateSO originSO;

        public StateAction[] actions;
        public StateCondition[] conditions;

        public string Name => originSO.Name;

        public void OnEnter()
        {
            Debug.Log(Name + " was Entered");
        }

        public void OnExit()
        {
        }

        public void OnUpdate()
        {
            for (var i = 0; i < actions.Length; i++)
            {
                actions[i].OnUpdate();
            }
        }

        public bool CanTransition()
        {
            bool isMet = false;

            for (var i = 0; i < conditions.Length; i++)
            {
                var condition = conditions[i];
                isMet = condition.IsMet();

                if (!isMet)
                {
                    break;
                }
            }

            return isMet;
        }

    }

}

