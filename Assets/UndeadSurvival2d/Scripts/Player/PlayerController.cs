using UnityEngine;
using Eincode.UndeadSurvival2d.Input;
using Eincode.UndeadSurvival2d.Abilities;

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

        private AbilityRunner _abilityRunner;

        private void OnEnable()
        {
            _inputReader.MoveEvent += OnMoveEvent;
            _inputReader.EvadeEvent += OnEvadeEvent;
        }

        private void OnDisable()
        {
            _inputReader.MoveEvent -= OnMoveEvent;
            _inputReader.EvadeEvent -= OnEvadeEvent;
        }

        private void Start()
        {
            _abilityRunner = GetComponent<AbilityRunner>();
        }

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

        private void OnEvadeEvent(bool isEvading)
        {
            if (isEvading)
            {
                AbilityStatus status = _abilityRunner.GetAbility("Evade", out var ability);

                if (status == AbilityStatus.IsReady)
                {
                    Debug.Log("Ability Casted!");
                    ability.Run();
                }
                else if (status == AbilityStatus.IsOnCooldown)
                {
                    Debug.Log($"{ability.originSO.Name} is on cooldown");
                }
                else
                {
                    Debug.Log("Ability is not found");
                }
            }
        }
    }
}


