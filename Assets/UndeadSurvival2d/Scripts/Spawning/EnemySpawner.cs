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

        [SerializeField]
        private SpawnConfigSO _spawnConfigSO;

        private float _spawnIntervalDelta;


        private void Update()
        {
            _spawnIntervalDelta += Time.deltaTime;

            if (SpawnTick)
            {
                Spawn();
                _spawnIntervalDelta = 0;
            }
        }

        private void Spawn()
        {
            Wave.EntityToSpawn.Instantiate(Vector2.one, transform);
        }
    }
}


