
using Eincode.UndeadSurvival2d.Player;
using UnityEngine;

namespace Eincode.UndeadSurvival2d.Reward.Scriptable
{
    public abstract class RewardSO : ScriptableObject
    {
        public GameObject RewardPrefab;

        public abstract void Apply(PlayerBehaviour player);

        public virtual void Drop(MonoBehaviour source)
        {
            var dropGO = Instantiate(RewardPrefab, source.transform.position, Quaternion.identity);

            if (dropGO.TryGetComponent(out RewardBehaviour reward))
            {
                reward.rewardData = this;
            }

        }
    }
}


