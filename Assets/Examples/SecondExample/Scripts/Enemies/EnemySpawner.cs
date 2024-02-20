using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner: IPause
{    
    private float _spawnCooldown;
    private List<Vector3> _spawnPoints = new List<Vector3>();
    private EnemyFactory _enemyFactory;

    private CourutinePerformer _context;

    private Coroutine _spawn;

    private bool _isPaused;

    [Inject]
    private void Construct( EnemySpawnerConfig spawnerConfig, EnemyFactory enemyFactory, CourutinePerformer context, PauseHandler pauseHandler)
    {
        _spawnCooldown = spawnerConfig.SpawnCooldown;
        _spawnPoints = spawnerConfig.SpawnPoints;
        _enemyFactory = enemyFactory;        
        _context = context;
        pauseHandler.Add(this);
    }

    public void StartWork()
    {
        StopWork();

        _spawn = _context.StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            _context.StopCoroutine(_spawn);
    }

    public void SetPause(bool isPause) => _isPaused = isPause;

    private IEnumerator Spawn()
    {
        float time = 0;

        while (true)
        {
            while (time < _spawnCooldown)
            {
                if (_isPaused == false)
                    time += Time.deltaTime;

                yield return null;
            }

            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));

            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)]);
            time = 0;
        }
    }
}
