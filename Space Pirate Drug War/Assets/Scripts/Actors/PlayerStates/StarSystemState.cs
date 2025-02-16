using UnityEngine;
using SPDW.Actors;
using SPDW.Locations;

namespace SPDW.StatePattern.PlayerStates
{
    public class StarSystemState : PlayerBaseState
    {
        public StarSystemState(Player player) : base(player) { }

        private StarSystem starSystem;
        private int selectedSite = 0;
        private float moveCooldown = 0.2f;
        private float lastMoveTime = 0;
        private bool errorChecksPassed = false;

        public override void Enter() {
            starSystem = GameObject.FindFirstObjectByType<StarSystem>();
            if (starSystem != null && starSystem.NavigableSites.Count > 0) {
                errorChecksPassed = true;
                starSystem.NavigableSites[selectedSite].gotFocus?.Invoke();
            }
        }
        
        public override void Exit() { }

        public override void Update() {
            if (Time.time - lastMoveTime > moveCooldown) {
                if (errorChecksPassed && player.MoveInput.x != 0) {
                    ChangeSelectedSite((int)player.MoveInput.x);
                }
            }
        }

        private void ChangeSelectedSite(int dir) {
            if (errorChecksPassed) {
                starSystem.NavigableSites[selectedSite].lostFocus?.Invoke();
                selectedSite = (selectedSite + dir + starSystem.NavigableSites.Count) % starSystem.NavigableSites.Count;
                starSystem.NavigableSites[selectedSite].gotFocus?.Invoke();
                lastMoveTime = Time.time;
            }
        }
    }
}
