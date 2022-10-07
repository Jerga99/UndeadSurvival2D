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
            var scale = _sprite.transform.localScale;
            _sprite.transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
            isFacingLeft = !isFacingLeft;
        }

        public bool GetFlipX()
        {
            return _sprite.flipX;
        }
    }
}


