using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Scriptable;

namespace Eincode.UndeadSurvival2d.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField]
        private StateSO[] _statesSO;

        // Use this for initialization
        void Start()
        {
            Debug.Log("Init StateMachine");
            Debug.Log(_statesSO[0].Name);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }


}