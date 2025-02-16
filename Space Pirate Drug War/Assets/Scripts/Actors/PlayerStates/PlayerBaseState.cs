using UnityEngine;
using SPDW.Actors;

namespace SPDW.StatePattern.PlayerStates
{
    public abstract class PlayerBaseState : IState
    {
        protected readonly Player player;

        protected PlayerBaseState(Player context) {
            player = context;
        }

        public virtual void Enter() {
            // no op
        }

        public virtual void Exit() {
            // no op
        }

        public virtual void Update() {
            // no op
        }

        public virtual void OnTriggerEnter(Collider other) {
            // no op
        }

        public virtual void OnTriggerExit(Collider other) {
            // no op
        }
    }
}