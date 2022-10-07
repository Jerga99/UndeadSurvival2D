using UnityEngine;
using Eincode.UndeadSurvival2d.Player;
using Eincode.UndeadSurvival2d.Persistance.Scriptable;
using Eincode.UndeadSurvival2d.Camera;

namespace Eincode.UndeadSurvival2d.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField]
        private PlayerBehaviour _player;

        [SerializeField]
        private GameStateSO _gameStateSO;

        [SerializeField]
        private GameOptionsSO _gameOptionsSO;

        [Header("Listening")]
        [SerializeField]
        private VoidEventChannelSO _playerDeadEvent;

        private void OnEnable()
        {
            _playerDeadEvent.OnEventRaised += HandleLooseCase;
        }

        private void OnDisable()
        {
            _playerDeadEvent.OnEventRaised -= HandleLooseCase;
        }

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

            var playerPrefab = _gameOptionsSO.heroChoice;
            var camera = UnityEngine.Camera.main.GetComponent<FollowCamera>();
            var playerGO = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);

            camera.FollowTo = playerGO.transform;
            _player = playerGO.GetComponent<PlayerBehaviour>();

            _gameStateSO.Reset();
        }

        private void Update()
        {
            _gameStateSO.GameTime += Time.deltaTime;
        }

        public PlayerBehaviour GetPlayer()
        {
            return _player;
        }

        public Vector3 GetPlayerPosition()
        {
            return _player.transform.position;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        private async void HandleLooseCase()
        {
            _gameStateSO.IsGameOver = true;
            await UIManager.Instance.DisplayLooseScreen();
            PauseGame();
        }
    }


}