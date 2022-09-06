using UnityEngine;

namespace Eincode.UndeadSurvival2d.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }


}