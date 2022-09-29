using UnityEngine;
using Eincode.UndeadSurvival2d.UI;
using TMPro;

namespace Eincode.UndeadSurvival2d.Manager
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        public RectTransform DamageCanvas;
        public GameObject DamageTextPrefab;
        public TextMeshProUGUI LevelText;
        public TextMeshProUGUI TimerText;

        [SerializeField]
        private ExperienceBar _expBar;

        [SerializeField]
        private IntValueSO _levelSO;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            LevelText.text = $"lvl: {_levelSO.RuntimeValue}";
        }

        public void SetExperience(int exp, int maxExp)
        {
            _expBar.SetValue(exp, maxExp);
        }

        public void ShowDamage(int damage, Transform target)
        {
            var damageGO = Instantiate(DamageTextPrefab, DamageCanvas.transform);
            var damageDisplay = damageGO.GetComponent<DamageDisplay>();

            damageDisplay.ShowDamage(damage, target, DamageCanvas);
        }
    }
}