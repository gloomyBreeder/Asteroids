using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : BasicManager<Spawner>
{
    private int GetRandomId<T>(List<T> list)
    {
        return UnityEngine.Random.Range(0, list.Count);
    }

    private T GetRandomPoint<T>(List<T> list)
    {
        int id = GetRandomId(list);
        return list[id];
    }

    public IEnumerator Spawn(SpawnerSettings settings, Action<GameObject, SpaceEnemyObject> action)
    {
        yield return new WaitForSeconds(settings.StartWait);
        while (true)
        {
            for (int i = 0; i < settings.Count; i++)
            {
                // get random point
                Transform spawnPoint = GetRandomPoint(settings.SpawnPoints);

                // get random obj
                int objectId = GetRandomId(settings.Objects);
                SpaceEnemyObject spaceObj = settings.Objects[objectId];
                GameObject obj = Instantiate(spaceObj.Prefab, spawnPoint.position, spawnPoint.rotation);
                ScoreKeeper score = obj.AddComponent<ScoreKeeper>();
                score.SetScore(spaceObj.Score);
                action(obj, spaceObj);

                yield return new WaitForSeconds(settings.SpawnWait);
            }
            yield return new WaitForSeconds(settings.WaveWait);
        }
    }

    public IEnumerator SpawnBonus(List<BonusSettings> bonuses, List<Transform> points, float spawnTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Transform spawnPoint = GetRandomPoint(points);

            int id = GetRandomId(bonuses);
            BonusSettings bonus = bonuses[id];

            GameObject obj = Instantiate(bonus.Prefab, spawnPoint.position, spawnPoint.rotation);
            Bonus b = obj.AddComponent<Bonus>();
            b.SetActionOnDestroy(bonus.BonusAction);
        }
    }
}
