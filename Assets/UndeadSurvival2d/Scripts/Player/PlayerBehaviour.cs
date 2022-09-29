using UnityEngine;
using Eincode.UndeadSurvival2d.Character;
using Eincode.UndeadSurvival2d.Reward;
using Eincode.UndeadSurvival2d.Manager;

namespace Eincode.UndeadSurvival2d.Player
{
    public class PlayerBehaviour : CharacterBehaviour
    {
        public float CoinDetectionRange;

        public int CurrentExperience
        {
            get => _currentExperienceSO.RuntimeValue;
            set => _currentExperienceSO.RuntimeValue = value;
        }

        public int Level
        {
            get => _levelSO.RuntimeValue;
            set => _levelSO.RuntimeValue = value;
        }

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

            UIManager.Instance.SetExperience(0, ExperienceToLevel);

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
            CurrentExperience += experience;

            if (CurrentExperience >= ExperienceToLevel)
            {
                var remainingExp = 0;

                if (CurrentExperience > ExperienceToLevel)
                {
                    remainingExp = CurrentExperience - ExperienceToLevel;
                }

                Level += 1;
                ExperienceToLevel += (Level * 10);
                CurrentExperience = remainingExp;
            }

            UIManager.Instance.SetExperience(
                CurrentExperience,
                ExperienceToLevel
            );
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

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Level: " + _levelSO.RuntimeValue);
            GUI.Label(new Rect(10, 30, 100, 20), "Cur Exp: " + _currentExperienceSO.RuntimeValue);
            GUI.Label(new Rect(10, 50, 100, 20), "Exp to lvl: " + ExperienceToLevel);
        }
    }
}

