using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnerSettings
{
    public List<SpaceEnemyObject> Objects = new List<SpaceEnemyObject>();
    // count of objects of one wave
    public int Count;
    // time before spawn
    public float StartWait;
    // time before wave of objects spawns
    public float WaveWait;
    // time before each object spawns
    public float SpawnWait;
    // spawn points
    public List<Transform> SpawnPoints = new List<Transform>();
}
