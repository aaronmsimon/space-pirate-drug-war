using UnityEngine;
using SPDW.Actors;
using SPDW.Locations;

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
        }
        
        public override void Exit() { }

        public override void Update() {
            if (canUpdate && Time.time - lastMoveTime > moveCooldown && player.MoveInput.x != 0) {
                starSystem.ChangeSelectedSite((int)player.MoveInput.x);
                lastMoveTime = Time.time;
            }
        }
    }
}
