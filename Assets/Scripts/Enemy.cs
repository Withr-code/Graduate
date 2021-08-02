using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(SphereCollider))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private AudioClip _audioClip;

    private Rigidbody _rigidbody;
    private Transform _target;
    private Vector3 _targetDirection;
    private MeshRenderer _renderer;
    private ScoreDisplay _scoreDisplay;
    private AudioSource _audioSource;
    private SphereCollider _collider;

    public event UnityAction Died;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<SphereCollider>();
        _audioSource = GetComponent<AudioSource>();
        _target = FindObjectOfType<PlayerInputHandler>().transform;
        _scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    private void FixedUpdate()
    {
        _targetDirection = _target.position - transform.position;

        _rigidbody.AddForce(_speed * _targetDirection, ForceMode.VelocityChange);
    }

    public void GetDamage()
    {
        _health--;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        StartCoroutine(StartDying());
    }

    private IEnumerator StartDying()
    {
        Disable();
        yield return new WaitForSeconds(0.5f);

        Enable();
        yield return null;
    }

    private void Disable()
    {
        _particles.Play();
        _audioSource.PlayOneShot(_audioClip);

        _renderer.enabled = false;
        _collider.enabled = false;
    }

    private void Enable()
    {
        gameObject.SetActive(false);
        _renderer.enabled = true;
        _collider.enabled = true;

        Died?.Invoke();
        _scoreDisplay.AddScore();
    }
}
