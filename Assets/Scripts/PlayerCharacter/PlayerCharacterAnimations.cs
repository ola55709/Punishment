using UnityEngine;

public class PlayerCharacterAnimations : MonoBehaviour
{
    private PlayerCharacterMovment _playerCharacterMovment;
    private Animator _animator;
    void Start()
    {
        _playerCharacterMovment = GetComponent<PlayerCharacterMovment>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        _animator.SetInteger("Horizontal Speed", (int)_playerCharacterMovment.PlayerHorizontalSpeed);
        _animator.SetBool("Is Jumping", _playerCharacterMovment.PlayerIsJumping);

        if (_playerCharacterMovment.PlayerHorizontalDirection < 0)
        {
            var scale = transform.localScale;
            scale.x = -Mathf.Abs(transform.localScale.x);
            transform.localScale = scale;
        }
        else if (_playerCharacterMovment.PlayerHorizontalDirection > 0)
        {
            var scale = transform.localScale;
            scale.x = Mathf.Abs(transform.localScale.x);
            transform.localScale = scale;
        }
    }
}
