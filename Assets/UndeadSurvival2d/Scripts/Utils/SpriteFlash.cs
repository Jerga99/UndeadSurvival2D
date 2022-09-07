using UnityEngine;
using System.Collections;


namespace Eincode.UndeadSurvival2d.Utils
{
    public class SpriteFlash : MonoBehaviour
    {
        public float Duration;
        public Material flashMaterial;

        private SpriteRenderer _spriteRenderer;
        private Material _originalMaterial;
        private Coroutine _flashRoutine;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalMaterial = _spriteRenderer.material;
            flashMaterial = new Material(flashMaterial);
        }

        public void Flash(Color color)
        {
            if (_flashRoutine != null)
            {
                StopCoroutine(_flashRoutine);
            }

            _flashRoutine = StartCoroutine(FlashRoutine(color));
        }


        private IEnumerator FlashRoutine(Color color)
        {
            _spriteRenderer.material = flashMaterial;
            flashMaterial.color = color;

            yield return new WaitForSeconds(Duration);

            _spriteRenderer.material = _originalMaterial;
            _flashRoutine = null;
        }
    }
}
