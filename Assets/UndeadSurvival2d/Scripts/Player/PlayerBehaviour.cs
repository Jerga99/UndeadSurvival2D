using UnityEngine;
using System.Collections;

namespace Eincode.UndeadSurvival2d.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private PlayerController _playerController;
        private Animator _animator;

        // Use this for initialization
        void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            var speed = Mathf.Round(_playerController.movementBlend * 100f) / 100f;
            _animator.SetFloat("Speed", speed);
        }
    }
}

