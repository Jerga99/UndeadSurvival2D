using UnityEngine;
using Eincode.UndeadSurvival2d.Spawning.Scriptable;
using Eincode.UndeadSurvival2d.Persistance.Scriptable;

namespace Eincode.UndeadSurvival2d.Spawning
{
    public enum SpawnSide
    {
        Top, Right, Bottom, Left
    }

    public class EnemySpawner : MonoBehaviour
    {
        [Range(0, 5)]
        public float SpawnRange;

        public SpawnConfigSO.SpawnConfig Wave => _spawnConfigSO.Waves[_gameStateSO.GameStage];
        public bool SpawnTick => _spawnIntervalDelta >= _spawnConfigSO.SpawnIntervalTime;

        public bool IsRoundFinished => _roundTime >= Wave.RoundTime;
        public bool IsThereNextRound => _gameStateSO.GameStage < _spawnConfigSO.Waves.Count - 1;

        [SerializeField]
        private SpawnConfigSO _spawnConfigSO;

        [SerializeField]
        private GameStateSO _gameStateSO;

        private float _spawnIntervalDelta;
        private float _roundTime;
        private readonly SpawnSide[] _spawnSides = {
            SpawnSide.Top,
            SpawnSide.Right,
            SpawnSide.Bottom,
            SpawnSide.Left
        };

        private void Update()
        {
            _spawnIntervalDelta += Time.deltaTime;
            _roundTime += Time.deltaTime;

            if (SpawnTick)
            {
                Spawn();
                _spawnIntervalDelta = 0;
            }
            else if (IsThereNextRound && IsRoundFinished)
            {
                GoToNextRound();
            }
        }

        private void GoToNextRound()
        {
            _gameStateSO.GameStage += 1;
            _spawnIntervalDelta = _roundTime = 0;
        }

        private void Spawn()
        {
            Vector2 spawnPosition = GetRandPositionBeyoundMap();

            Wave.EntityToSpawn.Instantiate(spawnPosition, transform);
        }

        private Vector2 GetRandPositionBeyoundMap()
        {
            float spawnX;
            float spawnY;

            SpawnSide side = _spawnSides[Random.Range(0, _spawnSides.Length)];

            if (side == SpawnSide.Top)
            {
                spawnX = Random.Range(0 - SpawnRange, 1f + SpawnRange);
                spawnY = Random.Range(1f, 1f + SpawnRange);
            }
            else if (side == SpawnSide.Right)
            {
                spawnX = Random.Range(1f, 1f + SpawnRange);
                spawnY = Random.Range(0, 1f);
            }
            else if (side == SpawnSide.Bottom)
            {
                spawnX = Random.Range(0 - SpawnRange, 1f + SpawnRange);
                spawnY = Random.Range(0, 0 - SpawnRange);
            }
            else
            {
                spawnX = Random.Range(0 - SpawnRange, 0);
                spawnY = Random.Range(0, 1f);
            }

            return UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(spawnX, spawnY));
        }
    }
}


