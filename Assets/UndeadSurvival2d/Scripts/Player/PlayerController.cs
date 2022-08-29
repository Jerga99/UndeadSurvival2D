using UnityEngine;
using System.Collections;

namespace Eincode.UndeadSurvival2d.Player
{
    public class PlayerController : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Debug.Log("Init Player Controller");
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - Time.deltaTime * 2,
                transform.position.z
            );
        }
    }
}


