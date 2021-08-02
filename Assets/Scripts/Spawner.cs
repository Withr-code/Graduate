using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawns;
    [Space]
    [SerializeField] private Enemy _template;
    [SerializeField] private Transform _pivot;
    [SerializeField] private Transform _container;
    [SerializeField] private int _enemyCount;

    private List<Enemy> _enemies = new List<Enemy>();

    private void Awake()
    {
        Enemy spawned;

        for (int i = 0; i < _enemyCount; i++)
        {
            spawned = Instantiate(_template, transform.position, Quaternion.identity, _container);
            spawned.gameObject.SetActive(false);

            _enemies.Add(spawned);

            ChangePosition();
            SpawnEnemy();
        }
    }

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += EnemyNeeded;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= EnemyNeeded;
        }
    }

    private void SpawnEnemy()
    {
        var neededEnemy = _enemies.FirstOrDefault(p => p.gameObject.activeSelf == false);

        if (neededEnemy != null)
        {
            neededEnemy.transform.position = transform.position;
            neededEnemy.gameObject.SetActive(true);
        }
    }

    private void ChangePosition()
    {
        var randomValue = Random.Range(6, 7.5f);

        transform.position = new Vector3(randomValue, 1, randomValue);
        _pivot.Rotate(Vector3.up, Random.Range(0, 360), Space.World);
    }

    private void EnemyNeeded()
    {
        ChangePosition();
        SpawnEnemy();
    }
}
