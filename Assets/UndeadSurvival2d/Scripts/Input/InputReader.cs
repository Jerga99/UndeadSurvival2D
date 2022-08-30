using System;
using UnityEngine;


namespace Eincode.UndeadSurvival2d.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]
    public class InputReader : ScriptableObject
    {
        public void OnMove(Vector2 value)
        {
            Debug.Log("Moving: " + value);
        }
    }
}

