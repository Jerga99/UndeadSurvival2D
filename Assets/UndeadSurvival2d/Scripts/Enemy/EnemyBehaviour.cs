using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Character;

namespace Eincode.UndeadSurvival2d.Enemy
{
    public class EnemyBehaviour : CharacterBehaviour
    {
        public string CollisionTag;

        new void Start()
        {
            base.Start();
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(CollisionTag))
            {
                Debug.Log("CollisionEnter!");
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(CollisionTag))
            {
                Debug.Log("CollisionExit!");
            }
        }

    }
}
