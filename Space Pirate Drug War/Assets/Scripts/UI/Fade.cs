using System.Collections;
using UnityEngine;

namespace SPDW.UI
{
    public class Fade : MonoBehaviour
    {
        [SerializeField] private float animationTime;

        private CanvasGroup canvasGroup;

        private void Awake() {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeTo(float newAlpha) {
            StartCoroutine(PerformFade(newAlpha));
        }

        private IEnumerator PerformFade(float endAlpha) {
            float startAlpha = canvasGroup.alpha;
            float elapsed = 0;

            while (elapsed < animationTime) {
                elapsed += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / animationTime);
                yield return null;
            }
        }
    }
}
