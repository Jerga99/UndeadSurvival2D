using UnityEngine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;

namespace Eincode.UndeadSurvival2d.StateMachine
{
    public class StateMachineCore : MonoBehaviour
    {
        [SerializeField]
        private StateSO[] _statesSO;

        private State _activeState;

        // Use this for initialization
        void Start()
        {
            _activeState = _statesSO[0].GetState();
            _activeState.OnEnter();
        }

        // Update is called once per frame
        void Update()
        {
            _activeState.OnUpdate();
        }
    }


}