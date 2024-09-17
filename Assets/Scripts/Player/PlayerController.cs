using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;

    [Header("Movement")]
    [SerializeField] private float _movSpeed;
    private float _speedX = 0, _speedY = 0;


    private void Start() {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate() {
        _animator.SetFloat("Horizontal1", _speedX);
        _animator.SetFloat("Vertical1", _speedY);
        float speedX = Input.GetAxisRaw("Horizontal") * _movSpeed;
        float speedY = Input.GetAxisRaw("Vertical") * _movSpeed;

        _animator.SetFloat("Horizontal", speedX);
        _animator.SetFloat("Vertical", speedY);

        _rb.velocity = new Vector2(speedX, speedY);

        _speedX = speedX;
        _speedY = speedY;
    }
}
