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
            var scale = _sprite.transform.parent.localScale;
            _sprite.transform.parent.localScale = new Vector3(-scale.x, scale.y, scale.z);
            isFacingLeft = !isFacingLeft;
        }

        public bool GetFlipX()
        {
            return _sprite.flipX;
        }

        public int GetPlayerDirection()
        {
            if (_sprite.transform.localScale.x >= 0)
            {
                // Right
                return +1;
            }
            else
            {
                // Left
                return -1;
            }
        }
    }
}


