using UnityEngine;
using UnityEngine.Events;

namespace SPDW.Locations
{
    public class NavigableSite : MonoBehaviour
    {
        [SerializeField] private string siteName;

        public UnityEvent gotFocus;
        public UnityEvent lostFocus;
    }
}
