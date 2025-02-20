using UnityEngine;
using SPDW.Actors;
using SPDW.Locations;
using SPDW.UI;

namespace SPDW.StatePattern.PlayerStates
{
    public class SiteState : PlayerBaseState
    {
        public SiteState(Player player) : base(player) { }

        private TabletArrow tabletArrow;
        private float moveCooldown = 0.2f;
        private float lastMoveTime = 0;
        private bool canUpdate = false;

        public override void Enter() {
            tabletArrow = GameObject.FindFirstObjectByType<TabletArrow>();
            if (tabletArrow == null) {
                Debug.LogError("No Tablet Arrow found.");
                return;
            }
            if (tabletArrow.ItemCount == 0) {
                Debug.LogError($"No items in tablet interface.");
                return;
            }
            canUpdate = true;

            player.InputReader.interactEvent += OnInteract;
        }
        
        public override void Exit() {
            player.InputReader.interactEvent -= OnInteract;
        }

        public override void Update() {
            if (canUpdate && Time.time - lastMoveTime > moveCooldown && player.MoveInput.y != 0) {
                // For joystick, round up
                int moveY = (int)(Mathf.Ceil(Mathf.Abs(player.MoveInput.y)) * Mathf.Sign(player.MoveInput.y));
                tabletArrow.ChangeItem(moveY);
                lastMoveTime = Time.time;
            }
        }

        private void OnInteract() {

        }
    }
}
