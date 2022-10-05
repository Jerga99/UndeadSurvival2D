using UnityEngine;
using Eincode.UndeadSurvival2d.Spawning.Scriptable;
using System;

namespace Eincode.UndeadSurvival2d.Spawning
{
    public class EnemySpawner : MonoBehaviour
    {
        public int GameStage;

        public SpawnConfigSO.SpawnConfig Wave => _spawnConfigSO.Waves[GameStage];
        public bool SpawnTick => _spawnIntervalDelta >= _spawnConfigSO.SpawnIntervalTime;

        public bool IsRoundFinished => _roundTime >= Wave.RoundTime;
        public bool IsThereNextRound => GameStage < _spawnConfigSO.Waves.Count - 1;

        [SerializeField]
        private SpawnConfigSO _spawnConfigSO;

        private float _spawnIntervalDelta;
        private float _roundTime;

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
                Debug.Log("Going to next round!");
            }
        }

        private void GoToNextRound()
        {
            GameStage += 1;
            _spawnIntervalDelta = _roundTime = 0;
        }

        private void Spawn()
        {
            Wave.EntityToSpawn.Instantiate(Vector2.one, transform);
        }
    }
}


