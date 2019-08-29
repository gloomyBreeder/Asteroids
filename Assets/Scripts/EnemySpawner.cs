using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BasicManager<EnemySpawner>
{
    [SerializeField]
    private SpawnerSettings _settings;

    [SerializeField]
    private Transform _player;

    public void StartSpawnEnemies()
    {
        StartCoroutine(Spawner.instance.Spawn(_settings, SpawnEnemy));
    }
    public void SpawnEnemy(GameObject enemy, SpaceEnemyObject settings)
    {
        Enemy enem = enemy.GetComponent<Enemy>();
        enem.StalkForPlayer(_player);
        enem.Health = settings.Health;
        enem.DamageLevel = settings.DamageLevel;
        enem.Speed = settings.Speed;
    }
}
