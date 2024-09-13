using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour, IPause
{
    [SerializeField] private float _spawnCooldown;

    [SerializeField] private List<Transform> _spawnPoints;

    private EnemyFactory _enemyFactory;

    private Coroutine _spawn;

    private bool _isPaused;

    [Inject]
    private void Construct(EnemyFactory enemyFactory, PauseHandler pauseHandler)
    {
        _enemyFactory = enemyFactory;
        pauseHandler.Add(this);
    }

    public void StartWork()
    {
        StopWork();

        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            StopCoroutine(_spawn);
    }

    private IEnumerator Spawn()
    {
        float time = 0;

        while (true)
        {
            while(time < _spawnCooldown)
            {
                if (_isPaused == false)
                    time += Time.deltaTime;

                yield return null;
            }

            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            time = 0;
        }
    }

    public void SetPause(bool isPaused) => _isPaused = isPaused;
}
