using System.Collections.Generic;
using System;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;

namespace SPDW.Locations
{
    public class StarSystem : MonoBehaviour
    {
        [Header("System Info")]
        [SerializeField] private string systemName;

        [Header("Scriptable Objects")]
        [SerializeField] private GameEvent siteSelectedGameEvent;
        [SerializeField] private StringVariable selectedSiteName;
        [SerializeField] private FloatVariable uiPosX;
        [SerializeField] private FloatVariable uiPosY;
        
        public event Action<NavigableSite> SiteSelected;

        private RectTransform canvas;
        private List<NavigableSite> navigableSites = new List<NavigableSite>();

        private int selectedSite = 0;

        private void Awake() {
            canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
            if (canvas == null) Debug.LogError("No Canvas in scene.");

            for (int i = 0; i < transform.childCount; i++) {
                NavigableSite site = transform.GetChild(i).GetComponent<NavigableSite>();
                if (site != null) navigableSites.Add(site);
            }
        }

        private void OnEnable() {
            foreach (NavigableSite navigableSite in navigableSites) {
                SiteSelected += navigableSite.OnSiteSelected;
            }
        }

        public void SelectFirstSite() {
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

            if (canvas != null) {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(selectedSite.transform.position);
                selectedSiteName.Value = selectedSite.SiteName;
                uiPosX.Value = screenPos.x;
                uiPosY.Value = screenPos.y;
                siteSelectedGameEvent.Raise();
            }
        }

        // ---- PROPERTIES ----
        public string SystemName => systemName;
        public List<NavigableSite> NavigableSites => navigableSites;
        public NavigableSite SelectedSite => navigableSites[selectedSite];
    }
}
