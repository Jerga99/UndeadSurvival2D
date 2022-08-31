using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Input;

namespace Eincode.UndeadSurvival2d.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float TargetSpeed;

        public Vector2 movementInput;
        public Vector3 movementVector;

        public float movementBlend;

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
            ComputeMovement();
            Move();
        }

        private void Move()
        {
            transform.position += movementVector;
        }

        private void ComputeMovement()
        {
            float targetSpeed = TargetSpeed;

            if (movementInput == Vector2.zero)
            {
                targetSpeed = 0;
            }

            var move = new Vector3(movementInput.x, movementInput.y, 0);

            movementBlend = Mathf.Lerp(movementBlend, targetSpeed, Time.deltaTime * 10f);
            movementVector = TargetSpeed * Time.deltaTime * move;
        }

        private void OnMoveEvent(Vector2 move)
        {
            movementInput = move;
        }
    }
}


