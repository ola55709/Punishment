using UnityEngine;

public class PlayerCharacterMovment : MonoBehaviour
{
    public float PlayerHorizontalSpeed { get; private set; }
    public int PlayerHorizontalDirection { get; private set; }
    public bool PlayerIsJumping { get; private set; }


    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private Collider2D _isGroundedColider;
    [SerializeField]
    private LayerMask _floorLayerMask;
    [SerializeField]
    private float _fallMultiplier = 2.5f;

    private PlayerMovment _controls;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _controls = new PlayerMovment();

        _controls.Player.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => _moveInput = Vector2.zero;

        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private bool IsGrounded()
    {
        if (_isGroundedColider != null && _isGroundedColider.IsTouchingLayers(_floorLayerMask) && _rb.linearVelocity.y <= 0) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        if (IsGrounded())
        {
            PlayerIsJumping = false;
            if (_controls.Player.Jump.WasPressedThisFrame())
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0f);
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                PlayerIsJumping = true;
            }
        }
    }   

    private void FixedUpdate()
    {
        if (_rb.linearVelocity.y < 1)
        {
            _rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        _rb.linearVelocity = new Vector2(_moveInput.x * _moveSpeed, _rb.linearVelocityY);
        PlayerHorizontalSpeed = Mathf.Abs(_rb.linearVelocity.x);
        PlayerHorizontalDirection = _rb.linearVelocity.x == 0f ? 0 : (int)Mathf.Sign(_rb.linearVelocity.x);
    }
}