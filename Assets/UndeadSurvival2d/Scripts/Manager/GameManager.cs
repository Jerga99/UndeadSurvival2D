using UnityEngine;
using Eincode.UndeadSurvival2d.Player;

namespace Eincode.UndeadSurvival2d.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField]
        private PlayerBehaviour _player;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public PlayerBehaviour GetPlayer()
        {
            return _player;
        }

        public Vector3 GetPlayerPosition()
        {
            return _player.transform.position;
        }
    }


}