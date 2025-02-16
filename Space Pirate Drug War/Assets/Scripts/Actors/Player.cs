using UnityEngine;
using SPDW.StatePattern;
using SPDW.StatePattern.PlayerStates;

namespace SPDW.Actors
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;

        private Vector2 moveInput;

        private StateMachine stateMachine;
        private StarSystemState starSystemState;

        private void Awake() {
            stateMachine = new StateMachine();
            starSystemState = new StarSystemState(this);
        }

        private void Start() {
            stateMachine.ChangeState(starSystemState);
        }

        private void OnEnable() {
            inputReader.moveEvent += OnMove;
        }

        private void OnDisable() {
            inputReader.moveEvent -= OnMove;
        }

        private void Update() {
            stateMachine.Update();
        }

        private void OnMove(Vector2 movement) {
            moveInput = movement;
        }

        // ---- PROPERTIES ----
        public Vector2 MoveInput => moveInput;

    }
}
