using System.Collections.Generic;
using UnityEngine;

namespace SPDW.Locations
{
    public class StarSystem : MonoBehaviour
    {
        [SerializeField] private List<NavigableSite> navigableSites;

        // ---- PROPERTIES ----
        public List<NavigableSite> NavigableSites => navigableSites;
    }
}
