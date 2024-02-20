using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IEnemyTarget
{
    private int _maxHealth;
    private int _health;

    public Vector3 Position => transform.position;

    [Inject]
    private void Construct(PlayerStatsConfig playerStatsConfig)
    {
        _maxHealth = _health = playerStatsConfig.MaxHealth;
        Debug.Log($"У меня {_health} хп");
    }

    public void TakeDamage(int damage)
    {
        //Проверка урона
        //Нанесение урона
    }
}
