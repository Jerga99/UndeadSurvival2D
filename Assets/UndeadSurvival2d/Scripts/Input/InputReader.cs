using System;
using UnityEngine;
using UnityEngine.Events;

namespace Eincode.UndeadSurvival2d.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]
    public class InputReader : ScriptableObject
    {
        public event UnityAction<Vector2> MoveEvent = delegate { };

        public void OnMove(Vector2 value)
        {
            MoveEvent.Invoke(value);
        }
    }
}

