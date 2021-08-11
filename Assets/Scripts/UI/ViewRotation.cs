using UnityEngine;

public class ViewRotation : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(0, _speed * Time.unscaledDeltaTime, 0, Space.Self);
    }
}
