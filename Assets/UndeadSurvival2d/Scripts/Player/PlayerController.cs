using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Input;

namespace Eincode.UndeadSurvival2d.Player
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField]
        private InputReader _inputReader;

        private void OnEnable()
        {
            _inputReader.MoveEvent += OnMoveEvent;
        }

        private void OnDisable()
        {
            _inputReader.MoveEvent -= OnMoveEvent;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - Time.deltaTime * 2,
                transform.position.z
            );
        }

        private void OnMoveEvent(Vector2 move)
        {
            Debug.Log("OnMoveEvent: " + move);
        }
    }
}


