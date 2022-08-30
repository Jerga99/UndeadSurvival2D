using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

namespace Eincode.UndeadSurvival2d.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField]
        private InputReader _inputReader;

        public void OnMove(InputValue value)
        {
            _inputReader.OnMove(value.Get<Vector2>());
        }
    }
}

