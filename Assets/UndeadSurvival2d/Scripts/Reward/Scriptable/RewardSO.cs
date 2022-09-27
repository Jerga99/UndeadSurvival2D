
using UnityEngine;

namespace Eincode.UndeadSurvival2d.Reward.Scriptable
{
    public abstract class RewardSO : ScriptableObject
    {
        public GameObject RewardPrefab;

        public virtual void Drop(MonoBehaviour source)
        {
            Instantiate(RewardPrefab, source.transform.position, Quaternion.identity);
        }
    }
}


