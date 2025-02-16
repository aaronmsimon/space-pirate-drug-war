using System.Collections.Generic;
using System;
using UnityEngine;

namespace SPDW.Locations
{
    public class StarSystem : MonoBehaviour
    {
        [SerializeField] private string systemName;
        [SerializeField] private List<NavigableSite> navigableSites;

        public event Action<NavigableSite> SiteSelected;

        private int selectedSite = 0;

        private void OnEnable() {
            foreach (NavigableSite navigableSite in navigableSites) {
                SiteSelected += navigableSite.OnSiteSelected;
            }
        }

        private void Start() {
            if (navigableSites.Count > 0) SelectSite(navigableSites[selectedSite]);
        }

        private void OnDisable() {
            foreach (NavigableSite navigableSite in navigableSites) {
                SiteSelected -= navigableSite.OnSiteSelected;
            }
        }

        public void ChangeSelectedSite(int dir) {
            selectedSite = (selectedSite + dir + NavigableSites.Count) % NavigableSites.Count;
            SelectSite(navigableSites[selectedSite]);
        }

        private void SelectSite(NavigableSite selectedSite) {
            SiteSelected?.Invoke(selectedSite);
        }

        // ---- PROPERTIES ----
        public string SystemName => systemName;
        public List<NavigableSite> NavigableSites => navigableSites;
    }
}
