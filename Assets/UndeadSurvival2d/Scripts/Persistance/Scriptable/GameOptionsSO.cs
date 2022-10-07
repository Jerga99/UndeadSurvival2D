using UnityEngine;

namespace Eincode.UndeadSurvival2d.Persistance.Scriptable
{
    [CreateAssetMenu(
        fileName = "GameOptionsSO",
        menuName = "Persistance/Game Options"
    )]
    public class GameOptionsSO : GameDataContainerSO
    {
        public GameObject heroChoice;

        public override void Reset()
        {
            heroChoice = default;
        }
    }
}
