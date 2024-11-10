using Entity.Enemy;
using UnityEngine;

namespace Entity.Player
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly int LastHorizontal = Animator.StringToHash("LastHorizontal");
        private static readonly int LastVertical = Animator.StringToHash("LastVertical");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private Animator _animator;
        private Rigidbody2D _rb;

        [Header("Movement")] [SerializeField] private float moveSpeed = 3;
        private float _speedX, _speedY;

        public Player Player { get; set; }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();

            Player = new Player("player", 10, 1, moveSpeed, 1f);
        }

        private void FixedUpdate()
        {
            _speedX = Input.GetAxisRaw("Horizontal");
            _speedY = Input.GetAxisRaw("Vertical");

            _animator.SetFloat(Horizontal, _speedX);
            _animator.SetFloat(Vertical, _speedY);

            _rb.velocity = new Vector2(_speedX, _speedY).normalized * moveSpeed;

            if (!Mathf.Approximately(Input.GetAxisRaw("Horizontal"), 1) &&
                !Mathf.Approximately(Input.GetAxisRaw("Horizontal"), -1) &&
                !Mathf.Approximately(Input.GetAxisRaw("Vertical"), 1) &&
                !Mathf.Approximately(Input.GetAxisRaw("Vertical"), -1)) return;
            _animator.SetFloat(LastHorizontal, Input.GetAxisRaw("Horizontal"));
            _animator.SetFloat(LastVertical, Input.GetAxisRaw("Vertical"));
        }

        public void OnColliderEnter2D(Collider2D other)
        {
            var enemy = other.gameObject.GetComponent<EnemyController>();
            if (enemy is not null)
            {
                Player.TakeDamage(1);
            }
        }
    }
}