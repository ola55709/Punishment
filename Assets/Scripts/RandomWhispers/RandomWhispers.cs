using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class RandomWhispers : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _soundClips;
    [SerializeField]
    public float _minInterval = 2f;
    [SerializeField]
    public float _maxInterval = 10f;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSounds());
    }

    IEnumerator PlayRandomSounds()
    {
        while (true)
        {
            float waitTime = Random.Range(_minInterval, _maxInterval);
            yield return new WaitForSeconds(waitTime);

            if (_soundClips.Length == 0)
            {
                continue;
            }
            AudioClip clip = _soundClips[Random.Range(0, _soundClips.Length)];
            _audioSource.clip = clip;

            _audioSource.panStereo = Random.value < 0.5f ? -1f : 1f;

            _audioSource.Play();
        }
    }
}
