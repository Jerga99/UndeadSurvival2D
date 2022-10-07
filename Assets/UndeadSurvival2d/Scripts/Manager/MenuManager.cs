using UnityEngine;
using Eincode.UndeadSurvival2d.Persistance.Scriptable;

namespace Eincode.UndeadSurvival2d.Manager
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager Instance { get; private set; }

        public GameObject InitialOpen;

        [SerializeField]
        private GameOptionsSO _gameOptionsSO;

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
            CloseCurrentMenu();
            _openMenu = menu;
        }

        public void CloseCurrentMenu()
        {
            if (_openMenu == null)
            {
                return;
            }

            _openMenu.SetActive(false);
            _openMenu = null;
        }

        public void SelectHero(GameObject hero)
        {
            _gameOptionsSO.heroChoice = hero;
        }
    }
}
