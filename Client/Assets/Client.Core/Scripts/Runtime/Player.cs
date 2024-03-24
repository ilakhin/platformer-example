using JetBrains.Annotations;
using UnityEngine;

namespace Client.Core
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class Player : MonoBehaviour
    {
        private static readonly int _runHash = Animator.StringToHash("run");

        [SerializeField]
        private LayerMask _groundLayerMask;

        [SerializeField]
        private float _runVelocity;

        [SerializeField]
        private Vector2 _jumpForce;

        private Animator _animator;
        private Collider2D _collider;
        private Rigidbody2D _rigidbody;

        private bool _grounded;

        public bool Jump
        {
            get;
            set;
        }

        public bool Running
        {
            get;
            set;
        }

        private void UpdateGrounded()
        {
            var bounds = _collider.bounds;
            var hit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0.1f, _groundLayerMask.value);

            _grounded = hit.collider != null;
        }

        [UsedImplicitly]
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        [UsedImplicitly]
        private void FixedUpdate()
        {
            UpdateGrounded();

            if (Jump)
            {
                Jump = false;
                _rigidbody.AddForce(_jumpForce, ForceMode2D.Impulse);
            }

            _animator.SetBool(_runHash, Running);

            if (Running)
            {
                _rigidbody.velocity = new Vector2(_runVelocity, _rigidbody.velocity.y);
            }
        }

        [UsedImplicitly]
        private void OnTriggerEnter2D(Collider2D other)
        {
            var triggerHandler = other.GetComponentInParent<ITriggerHandler>();

            triggerHandler?.OnEnter();
        }

        [UsedImplicitly]
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _grounded)
            {
                Jump = true;
            }
        }
    }
}
