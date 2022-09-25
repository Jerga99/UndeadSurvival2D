using UnityEngine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;

namespace Eincode.UndeadSurvival2d.StateMachine
{
    public class StateMachineCore : MonoBehaviour
    {
        [SerializeField]
        private StateSO[] _statesSO;

        private State[] _states;
        private int _currentState;

        void Start()
        {
            _currentState = 0;
            InitialStates();
            _states[_currentState].OnEnter();
        }

        void Update()
        {
            var currentState = _states[_currentState];
            currentState.OnUpdate();

            if (currentState.CanTransition())
            {
                Debug.Log("Can Transition to New State!");
            }
        }

        private void InitialStates()
        {
            var stateLength = _statesSO.Length;
            _states = new State[stateLength];

            for (var i = 0; i < stateLength; i++)
            {
                var state = _statesSO[i].GetState(this);
                _states[i] = state;
            }
        }
    }


}