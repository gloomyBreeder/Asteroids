using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : BasicManager<AsteroidSpawner>
{
    [SerializeField]
    private SpawnerSettings _settings;
    public void StartSpawnAsteroids()
    {
        StartCoroutine(Spawner.instance.Spawn(_settings, SpawnAsteroid));
    }
    public void SpawnAsteroid(GameObject asteroid, SpaceEnemyObject settings)
    {
        Asteroid aster = asteroid.GetComponent<Asteroid>();
        aster.Health = settings.Health;
        aster.DamageLevel = settings.DamageLevel;
        aster.Speed = settings.Speed;
    }
}

