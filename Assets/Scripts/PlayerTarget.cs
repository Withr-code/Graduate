using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    private Transform _target;
    private Vector3 _defaultPosition;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerMovement>().transform;
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        transform.position = _target.position + _defaultPosition;
    }
}
