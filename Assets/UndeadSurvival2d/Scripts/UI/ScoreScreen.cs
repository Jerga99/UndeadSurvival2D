using UnityEngine;
using Eincode.UndeadSurvival2d.Persistance.Scriptable;
using TMPro;

namespace Eincode.UndeadSurvival2d.UI
{
    public class ScoreScreen : MonoBehaviour
    {
        [SerializeField]
        private GameStateSO _gameStateSO;

        public TextMeshProUGUI ScoreText;
        public TextMeshProUGUI EnemiesDefeatedText;

        void Update()
        {
            ScoreText.text = $"Score: {_gameStateSO.Score}";
            EnemiesDefeatedText.text = $"Enemies Defeated: {_gameStateSO.EnemiesDefeated}";
        }
    }


}
