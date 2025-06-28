using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CamerPossition : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Vector2 _cameraOffset;
    [SerializeField]
    private float _smoothness;
    [SerializeField]
    public float _followThreshold = 0.1f;

    private Vector3 _velocity = Vector3.zero;


    void LateUpdate()
    {
        var targetPossition = new Vector3(_player.transform.position.x + _cameraOffset.x, _player.transform.position.y + _cameraOffset.y, transform.position.z);

        float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(_player.transform.position.x, _player.transform.position.y));

        if (distance > _followThreshold)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPossition, ref _velocity, _smoothness);
        }
    }
}
