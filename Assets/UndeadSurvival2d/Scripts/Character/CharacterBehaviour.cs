using UnityEngine;
using System.Collections;

namespace Eincode.UndeadSurvival2d.Character
{
    public class CharacterBehaviour : MonoBehaviour
    {
        protected SpriteRenderer _sprite;

        protected void Start()
        {
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _sprite.flipX = true;
        }
    }
}


