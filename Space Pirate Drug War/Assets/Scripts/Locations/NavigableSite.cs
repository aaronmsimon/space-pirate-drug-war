using UnityEngine;
using UnityEngine.Events;

namespace SPDW.Locations
{
    public class NavigableSite : MonoBehaviour
    {
        [SerializeField] private string siteName;

        public UnityEvent gotFocus;
        public UnityEvent lostFocus;

        public void OnSiteSelected(NavigableSite selectedSite) {
            if (selectedSite == this) {
                gotFocus?.Invoke();
            } else {
                lostFocus?.Invoke();
            }
        }
    }
}
