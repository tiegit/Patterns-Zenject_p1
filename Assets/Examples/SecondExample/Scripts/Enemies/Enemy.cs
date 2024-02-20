using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, IPause
{
    private int _health;
    private float _speed;

    private IEnemyTarget _target;

    PauseHandler _pauseHandler;

    private bool _isPaused;

    [Inject]
    private void Construct(IEnemyTarget enemyTarget, PauseHandler pauseHandler)
    {
        _target = enemyTarget;
        _pauseHandler = pauseHandler;
        _pauseHandler.Add(this);
    }

    public virtual void Initialize(int helath, float speed)
    {
        _health = helath;
        _speed = speed;

        Debug.Log($"ХП: {_health}, скорость: {_speed}");
    }

    private void Update()
    {
        if (_isPaused)
            return;

        Vector3 direction = (_target.Position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    public void MoveTo(Vector3 position) => transform.position = position;

    public void SetPause(bool isPause) => _isPaused = isPause;
}
