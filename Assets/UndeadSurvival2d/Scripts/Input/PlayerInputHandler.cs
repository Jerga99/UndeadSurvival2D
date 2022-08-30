using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

namespace Eincode.UndeadSurvival2d.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public void OnMove(InputValue value)
        {
            Debug.Log(value.Get<Vector2>());
        }
    }
}

