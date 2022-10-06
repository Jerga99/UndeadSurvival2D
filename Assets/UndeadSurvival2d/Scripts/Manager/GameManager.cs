using UnityEngine;
using Eincode.UndeadSurvival2d.Player;
using Eincode.UndeadSurvival2d.Persistance.Scriptable;

namespace Eincode.UndeadSurvival2d.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField]
        private PlayerBehaviour _player;

        [SerializeField]
        private GameStateSO _gameStateSO;

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

        private async void HandleLooseCase()
        {
            await UIManager.Instance.DisplayLooseScreen();
            Debug.Log("Display buttons and so on...");
            Debug.Log("Game is Lost!");
        }
    }


}