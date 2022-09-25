using UnityEngine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;

namespace Eincode.UndeadSurvival2d.StateMachine
{
    public class StateMachineCore : MonoBehaviour
    {
        public State CurrentState => _states[_currentState];

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
            CurrentState.OnUpdate();

            if (CurrentState.CanTransition())
            {
                Transition();
            }
        }

        private void Transition()
        {
            Debug.Log("Exiting: " + CurrentState.Name);
            CurrentState.OnExit();
            GoToNextState();
        }

        private void GoToNextState()
        {
            _currentState++;
            Debug.Log("Entering: " + CurrentState.Name);
            CurrentState.OnEnter();
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