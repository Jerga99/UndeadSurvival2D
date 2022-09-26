using UnityEngine;
using Eincode.UndeadSurvival2d.Manager;

namespace Eincode.UndeadSurvival2d.Reward
{
    public class RewardBehaviour : MonoBehaviour
    {
        public LayerMask InteractWith;

        private void Update()
        {
            var playerPosition = GameManager.Instance.GetPlayerPosition();

            transform.position = Vector3.MoveTowards(
                transform.position,
                playerPosition,
                Time.deltaTime * 2.3f
            );
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((InteractWith.value & 1 << collision.gameObject.layer) > 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

