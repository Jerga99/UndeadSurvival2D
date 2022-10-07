using UnityEngine;

namespace Eincode.UndeadSurvival2d.Manager
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager Instance { get; private set; }

        public GameObject InitialOpen;

        private GameObject _openMenu;

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

        private void Start()
        {
            OpenMenu(InitialOpen);
        }

        public void OpenMenu(GameObject menu)
        {
            if (_openMenu == menu)
            {
                return;
            }

            menu.SetActive(true);
            _openMenu = menu;
        }
    }
}
