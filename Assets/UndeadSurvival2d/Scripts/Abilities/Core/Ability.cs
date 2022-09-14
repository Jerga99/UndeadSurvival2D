

using UnityEngine;

namespace Eincode.UndeadSurvival2d.Abilities
{
    public abstract class Ability
    {
        public abstract void TriggerAbility();

        public virtual void Awake(MonoBehaviour runner) { }
        public virtual void Run() { }
    }
}



