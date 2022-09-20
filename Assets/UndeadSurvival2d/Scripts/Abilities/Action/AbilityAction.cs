using UnityEngine;




namespace Eincode.UndeadSurvival2d.Abilities.Action
{
    public class AbilityAction : MonoBehaviour
    {
        public LayerMask CollideWith;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((CollideWith.value & 1 << collision.transform.gameObject.layer) > 0)
            {
                Debug.Log("Attack has landed!");
            }
        }
    }
}


