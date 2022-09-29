
using UnityEngine;

namespace Eincode.UndeadSurvival2d.Persistance.Scriptable
{
    [CreateAssetMenu(fileName = "GameStateSO", menuName = "Game/Game State SO")]
    public class GameStateSO : GameDataContainerSO
    {
        [SerializeField]
        private FloatValueSO _gameTimeSO;

        public float GameTime
        {
            get => _gameTimeSO.RuntimeValue;
            set => _gameTimeSO.RuntimeValue = value;
        }

        public override void Reset()
        {
            _gameTimeSO.ResetValue();
        }
    }
}


