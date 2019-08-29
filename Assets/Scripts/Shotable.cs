using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Shotable
{
    public float FireRate;
    [HideInInspector]
    public float NextFire;
    public GameObject BulletPrefab;
    public List<Transform> ShotSpawns = new List<Transform>();
    [HideInInspector]
    //cache old rate in case of changing
    public float OldRate;
}
