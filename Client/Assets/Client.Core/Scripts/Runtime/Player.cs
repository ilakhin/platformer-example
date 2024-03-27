using JetBrains.Annotations;
using UnityEngine;

namespace Client.Core
{
    // Игрок.
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : MonoBehaviour, IPlayer
    {
        private static readonly int _groundedHash = Animator.StringToHash("grounded");

        [SerializeField]
        private LayerMask _groundLayerMask;

        [SerializeField]
        private float _runningVelocity;

        [SerializeField]
        private float _jumpingDuration;

        [SerializeField]
        private float _jumpingVelocity;

        private Animator _animator;
        private Collider2D _collider;
        private Rigidbody2D _rigidbody;

        private ICollisionManager _collisionManager;

        private bool _grounded;
        private bool _running;
        private bool _jumping;

        private float _runningVelocityRatio = 1f;
        private float _jumpingVelocityRatio = 1f;
        private float _jumpingTime;

        public void Initialize(ICollisionManager collisionManager)
        {
            _collisionManager = collisionManager;
        }

        private void UpdateGrounded()
        {
            var bounds = _collider.bounds;
            var hit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0.1f, _groundLayerMask.value);
            var grounded = hit.collider != null;

            _grounded = grounded;
            _animator.SetBool(_groundedHash, grounded);
        }

        private void UpdateJumping()
        {
            if (!_jumping)
            {
                return;
            }

            _jumpingTime += Time.deltaTime;

            if (_jumpingTime > _jumpingDuration)
            {
                _jumping = default;
            }
        }

        private void UpdateVelocity()
        {
            var xVelocity = _running
                ? _runningVelocityRatio * _runningVelocity
                : _rigidbody.velocity.x;

            var yVelocity = _jumping
                ? _jumpingVelocityRatio * _jumpingVelocity
                : _rigidbody.velocity.y;

            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
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
            UpdateVelocity();
        }

        [UsedImplicitly]
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<ITrigger>(out var trigger))
            {
                _collisionManager.OnTriggerEnter(this, trigger);
            }
        }

        [UsedImplicitly]
        private void Update()
        {
            UpdateJumping();
        }

        Rigidbody2D IPlayer.Rigidbody => _rigidbody;

        bool IPlayer.Running
        {
            get => _running;
            set => _running = value;
        }

        float IPlayer.RunningVelocityRatio
        {
            get => _runningVelocityRatio;
            set => _runningVelocityRatio = value;
        }

        bool IPlayer.Jumping
        {
            get => _jumping;
            set
            {
                if (value)
                {
                    if (!_grounded)
                    {
                        return;
                    }

                    _jumping = true;
                    _jumpingTime = default;
                }
                else
                {
                    _jumping = false;
                }
            }
        }

        float IPlayer.JumpingVelocityRatio
        {
            get => _jumpingVelocityRatio;
            set => _jumpingVelocityRatio = value;
        }
    }
}
