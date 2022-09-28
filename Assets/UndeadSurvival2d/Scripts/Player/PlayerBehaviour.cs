using UnityEngine;
using Eincode.UndeadSurvival2d.Character;
using Eincode.UndeadSurvival2d.Reward;

namespace Eincode.UndeadSurvival2d.Player
{
    public class PlayerBehaviour : CharacterBehaviour
    {
        public float CoinDetectionRange;

        private PlayerController _playerController;
        private Animator _animator;

        public int ExperienceToLevel;

        [SerializeField]
        private IntValueSO _levelSO;
        [SerializeField]
        private IntValueSO _currentExperienceSO;

        void Awake()
        {
            _levelSO.ResetValue();
            _currentExperienceSO.ResetValue();
        }

        // Use this for initialization
        new void Start()
        {
            base.Start();
            _playerController = GetComponent<PlayerController>();
            _animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            TargetNearbyItems();

            if (_playerController.movementInput.x < 0 && !isFacingLeft ||
                _playerController.movementInput.x > 0 && isFacingLeft)
            {
                Flip();
            }

            var speed = Mathf.Round(_playerController.movementBlend * 100f) / 100f;
            _animator.SetFloat("Speed", speed);
        }

        public void SetExperience(int experience)
        {
            _currentExperienceSO.RuntimeValue += experience;
            Debug.Log(_currentExperienceSO.RuntimeValue);
        }

        private void TargetNearbyItems()
        {
            Collider2D[] items = Physics2D.OverlapCircleAll(transform.position, CoinDetectionRange);

            foreach (Collider2D collider in items)
            {
                if (collider.TryGetComponent(out RewardBehaviour item) && !item.isTargeted)
                {
                    item.isTargeted = true;
                }
            }
        }
    }
}

