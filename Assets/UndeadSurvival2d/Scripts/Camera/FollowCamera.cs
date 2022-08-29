using UnityEngine;
using System.Collections;

namespace Eincode.UndeadSurvival2d.Camera
{
    public class FollowCamera : MonoBehaviour
    {
        public Transform FollowTo;
        public Vector3 Offset;
        public float CameraDistance;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = new Vector3(
                FollowTo.position.x + Offset.x,
                FollowTo.position.y + Offset.y,
                CameraDistance
            );
        }
    }
}

