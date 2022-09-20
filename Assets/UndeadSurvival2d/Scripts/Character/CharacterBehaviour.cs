using UnityEngine;
using System.Collections;

namespace Eincode.UndeadSurvival2d.Character
{
    public class CharacterBehaviour : MonoBehaviour
    {
        public bool isFacingLeft = default;
        private SpriteRenderer _sprite;

        protected void Start()
        {
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }

        public void Flip()
        {
            isFacingLeft = _sprite.flipX = !_sprite.flipX;
        }

        public bool GetFlipX()
        {
            return _sprite.flipX;
        }
    }
}


