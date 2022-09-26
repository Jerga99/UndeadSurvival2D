using UnityEngine;

namespace Eincode.UndeadSurvival2d.Reward
{
    public class RewardBehaviour : MonoBehaviour
    {
        public LayerMask InteractWith;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((InteractWith.value & 1 << collision.gameObject.layer) > 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

