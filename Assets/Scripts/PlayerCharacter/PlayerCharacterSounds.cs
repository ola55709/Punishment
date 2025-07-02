using UnityEngine;

public class PlayerCharacterSounds : MonoBehaviour
{
    [SerializeField]
    private float footstepsVolume = 0.6f;
    [SerializeField]
    private AudioSource[] _footstepsAudioSources;

    private int _currentFootstepsAudioSource = 0;
    private int _prevFootstepsAudioSource = 0;
    private PlayerCharacterMovment _playerCharacterMovment;
    void Start()
    {
        _playerCharacterMovment = GetComponent<PlayerCharacterMovment>();
    }

    void Update()
    {
        if (!_footstepsAudioSources[_prevFootstepsAudioSource].isPlaying && _playerCharacterMovment.PlayerHorizontalSpeed != 0 && !_playerCharacterMovment.PlayerIsJumping)
        {
            _footstepsAudioSources[_currentFootstepsAudioSource].volume = footstepsVolume;
            _footstepsAudioSources[_currentFootstepsAudioSource].Play();
            _prevFootstepsAudioSource = _currentFootstepsAudioSource;
            _currentFootstepsAudioSource = _footstepsAudioSources.Length - 1 == _currentFootstepsAudioSource ? 0 : _currentFootstepsAudioSource + 1;
        }
    }
}
