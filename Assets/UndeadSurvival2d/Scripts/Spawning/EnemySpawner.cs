using UnityEngine;
using Eincode.UndeadSurvival2d.Spawning.Scriptable;

namespace Eincode.UndeadSurvival2d.Spawning
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private SpawnConfigSO _spawnConfigSO;


        private void Start()
        {
            foreach (var wave in _spawnConfigSO.Waves)
            {
                Debug.Log("Should Spawn: " + wave.EntityToSpawn);
                Debug.Log("Round Time: " + wave.RoundTime);
            }
        }
    }
}


