using UnityEngine;
using System.Collections;
using Eincode.UndeadSurvival2d.Character;

namespace Eincode.UndeadSurvival2d.Enemy
{
    public class EnemyBehaviour : CharacterBehaviour
    {
        new void Start()
        {
            base.Start();
            Debug.Log("Init EnemyBehaviour");
        }

        void Update()
        {

        }
    }


}
