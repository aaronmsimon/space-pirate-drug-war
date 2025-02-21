using UnityEngine;
using UnityEngine.Splines;
using SPDW.StatePattern;
using SPDW.StatePattern.PlayerStates;
using RoboRyanTron.Unite2017.Events;
using Unity.Mathematics;

namespace SPDW.Actors
{
    public class Player : MonoBehaviour
    {
        [Header("Game Events")]
        [SerializeField] private GameEvent travelToSiteGameEvent;

        [Header("Input")]
        [SerializeField] private InputReader inputReader;

        private Vector2 moveInput;
        private Animator animator;
        private SplineAnimate splineAnimate;
        private TrailRenderer trailRenderer;

        private StateMachine stateMachine;
        private StarSystemState starSystemState;
        private SiteState siteState;

        private void Awake() {
            animator = GetComponentInChildren<Animator>();
            splineAnimate = GetComponent<SplineAnimate>();
            trailRenderer = GetComponentInChildren<TrailRenderer>();

            stateMachine = new StateMachine();
            starSystemState = new StarSystemState(this);
            siteState = new SiteState(this);
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

        public void Reset() {
            trailRenderer.enabled = false;
            transform.position = Vector3.zero;
            animator.Rebind();
            animator.Update(0);
            transform.rotation = quaternion.identity;
            trailRenderer.enabled = true;
        }

        // ---- PROPERTIES ----
        public InputReader InputReader => inputReader;
        public Vector2 MoveInput => moveInput;
        public SplineAnimate SplineAnimator => splineAnimate;
        public GameEvent TravelToSiteGameEvent => travelToSiteGameEvent;
        public StateMachine StateMachine => stateMachine;
        public StarSystemState StarSystemState => starSystemState;
        public SiteState SiteState => siteState;

    }
}
