using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;
    [SerializeField] private CourutinePerformer _courutinePerformer;

    public override void InstallBindings()
    {
        BindEnemySpawnerConfig();
        BindEnemyFactory();
        BindCouritineContext();

        BindEnemySpawner();
    }

    private void BindEnemySpawner() => Container.Bind<EnemySpawner>().AsSingle();
    
    private void BindCouritineContext() => Container.Bind<CourutinePerformer>().FromInstance(_courutinePerformer).AsTransient();

    private void BindEnemyFactory() => Container.Bind<EnemyFactory>().AsSingle();
    
    private void BindEnemySpawnerConfig() => Container.Bind<EnemySpawnerConfig>().FromInstance(_enemySpawnerConfig).AsSingle();
}
