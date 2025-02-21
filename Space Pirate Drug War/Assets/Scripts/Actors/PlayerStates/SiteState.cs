using UnityEngine;
using SPDW.Actors;
using SPDW.Menu;

namespace SPDW.StatePattern.PlayerStates
{
    public class SiteState : PlayerBaseState
    {
        public SiteState(Player player) : base(player) { }

        private MenuNavigation menuNavigation;
        private float moveCooldown = 0.2f;
        private float lastMoveTime = 0;

        public override void Enter() {
            menuNavigation = GameObject.FindFirstObjectByType<MenuNavigation>();

            player.InputReader.interactEvent += OnInteract;
        }
        
        public override void Exit() {
            player.InputReader.interactEvent -= OnInteract;
        }

        public override void Update() {
            if (Time.time - lastMoveTime > moveCooldown && player.MoveInput.y != 0) {
                // For joystick, round up
                int moveY = (int)(Mathf.Ceil(Mathf.Abs(player.MoveInput.y)) * Mathf.Sign(player.MoveInput.y));
                menuNavigation.Navigate(-moveY);
                lastMoveTime = Time.time;
            }
        }

        private void OnInteract() {
            menuNavigation.SelectCurrentItem();
        }
    }
}
