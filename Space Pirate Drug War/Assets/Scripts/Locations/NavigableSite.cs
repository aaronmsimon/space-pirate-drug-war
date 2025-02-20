using UnityEngine;
using UnityEngine.Events;
using RoboRyanTron.Unite2017.Events;

namespace SPDW.Locations
{
    public class NavigableSite : MonoBehaviour
    {
        [SerializeField] private string siteName;
        [SerializeField] private GameEvent reachedSiteGameEvent;

        public UnityEvent gotFocus;
        public UnityEvent lostFocus;

        public void OnSiteSelected(NavigableSite selectedSite) {
            if (selectedSite == this) {
                gotFocus?.Invoke();
            } else {
                lostFocus?.Invoke();
            }
        }

        private void OnTriggerEnter() {
            reachedSiteGameEvent.Raise();
        }

        // ---- PROPERTIES ----
        public string SiteName => siteName;
    }
}
