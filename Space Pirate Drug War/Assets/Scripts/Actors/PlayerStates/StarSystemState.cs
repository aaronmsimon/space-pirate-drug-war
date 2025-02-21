using UnityEngine;
using SPDW.Actors;
using SPDW.Locations;
using SPDW.Splines;

namespace SPDW.StatePattern.PlayerStates
{
    public class StarSystemState : PlayerBaseState
    {
        public StarSystemState(Player player) : base(player) { }

        private StarSystem starSystem;
        private float moveCooldown = 0.2f;
        private float lastMoveTime = 0;
        private bool canUpdate = false;

        public override void Enter() {
            starSystem = GameObject.FindFirstObjectByType<StarSystem>();
            if (starSystem == null) {
                Debug.LogError("No Star System found.");
                return;
            }
            if (starSystem.NavigableSites.Count == 0) {
                Debug.LogError($"No Navigable Sites found in Star System {starSystem.SystemName}.");
                return;
            }
            canUpdate = true;

            player.Reset();
            starSystem.SelectFirstSite();

            player.InputReader.interactEvent += OnInteract;
        }
        
        public override void Exit() {
            player.InputReader.interactEvent -= OnInteract;
        }

        public override void Update() {
            if (canUpdate && Time.time - lastMoveTime > moveCooldown && player.MoveInput.x != 0) {
                // For joystick, round up
                int moveX = (int)(Mathf.Ceil(Mathf.Abs(player.MoveInput.x)) * Mathf.Sign(player.MoveInput.x));
                starSystem.ChangeSelectedSite(moveX);
                lastMoveTime = Time.time;
            }
        }

        private void OnInteract() {
            SplinePath spline = starSystem.SelectedSite.GetComponent<SplinePath>();
            if (spline != null) {
                player.SplineAnimator.Container = spline.SplineContainer;
                player.PlaySpline();
            } else {
                Debug.LogError($"No spline flight path assigned to {starSystem.SelectedSite.SiteName}");
            }
            player.TravelToSiteGameEvent.Raise();
            player.StateMachine.ChangeState(player.SiteState);
        }
    }
}
