using UnityEngine;
using UnityEngine.Splines;
using SPDW.StatePattern;
using SPDW.StatePattern.PlayerStates;

namespace SPDW.Actors
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;

        private Vector2 moveInput;
        private Animator animator;
        private SplineAnimate splineAnimate;

        private StateMachine stateMachine;
        private StarSystemState starSystemState;

        private void Awake() {
            animator = GetComponentInChildren<Animator>();
            splineAnimate = GetComponentInChildren<SplineAnimate>();

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

        public void PlaySpline() {
            splineAnimate.Play();
            animator.Play("Travel");
        }

        private void OnMove(Vector2 movement) {
            moveInput = movement;
        }

        // ---- PROPERTIES ----
        public InputReader InputReader => inputReader;
        public Vector2 MoveInput => moveInput;
        public SplineAnimate SplineAnimator => splineAnimate;

    }
}
