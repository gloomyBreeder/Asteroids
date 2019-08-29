using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : SpaceObject
{
    public override float Health { get; set; }
    public override float DamageLevel { get; set; }
    public override float Speed { get; set; }

    void Start()
    {
        Movable movable = GetComponent<Movable>();
        movable.SetSpeed(Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.DamageMe(player, DamageLevel);
            DestroyObject(gameObject);
        }
    }
}
