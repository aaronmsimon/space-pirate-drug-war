using UnityEngine;
using TMPro;
using RoboRyanTron.Unite2017.Variables;

namespace SPDW.UI
{
    public class SingleMessage : MonoBehaviour
    {
        [Header("UI Info")]
        [SerializeField] private TMP_Text textDisplay;
        [SerializeField] private GameObject graphics;
        [SerializeField] private Vector2 offset;

        [Header("Scriptable Objects")]
        [SerializeField] private StringVariable selectedSiteName;
        [SerializeField] private FloatVariable uiPosX;
        [SerializeField] private FloatVariable uiPosY;

        private RectTransform rectTransform;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnSiteSelectedGameEvent() {
            rectTransform.anchoredPosition = new Vector2(uiPosX.Value, uiPosY.Value) + offset;
            SetMessage(selectedSiteName.Value);
            SetVisibility(true);
        }

        public void HideMessage() {
            SetVisibility(false);
        }

        private void SetMessage(string message) {
            textDisplay.text = message;
        }

        private void SetVisibility(bool visibility) {
            graphics.SetActive(visibility);
        }
    }
}
