using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "EnemySpawner/Config")]
public class EnemySpawnerConfig : ScriptableObject
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Vector3> _spawnPoints;

    public float SpawnCooldown => _spawnCooldown;
    public List<Vector3> SpawnPoints => _spawnPoints;
}
