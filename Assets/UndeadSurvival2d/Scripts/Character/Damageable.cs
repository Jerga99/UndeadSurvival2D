using UnityEngine;
using System.Collections;

namespace Eincode.UndeadSurvival2d.Character
{
    public class Damageable : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(int damage)
        {
            Debug.Log("Taking Damage of: " + damage);
        }
    }
}


