using UnityEngine;
using System.Collections;


namespace Eincode.UndeadSurvival2d.Utils
{
    public class SpriteFlash : MonoBehaviour
    {
        public Material flashMaterial;

        private SpriteRenderer _spriteRenderer;
        private Material _originalMaterial;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalMaterial = _spriteRenderer.material;
            flashMaterial = new Material(flashMaterial);
        }
    }
}
