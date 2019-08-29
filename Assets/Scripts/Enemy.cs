using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SpaceObject
{
    public override float Health { get; set; }
    public override float DamageLevel { get; set; }
    public override float Speed { get; set; }

    [SerializeField]
    private Shotable _shotable;
    private Rigidbody _rb;
    private Transform _player;

    private enum Movements
    {
        None,
        Linear,
        Circle,
        ZigZag
    }

    private Movements _movement;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        // check movement pattern
        if (GetComponent<EnemyCircleMovement>() != null)
            _movement = Movements.Circle;
        else if (GetComponent<EnemyZigZagMovement>() != null)
            _movement = Movements.ZigZag;
        else
            _movement = Movements.Linear;
    }
    void Update()
    {
        if (Time.time > _shotable.NextFire)
        {
            _shotable.NextFire = Time.time + _shotable.FireRate;
            Attack(this, _shotable.BulletPrefab, _shotable.ShotSpawns);
        }
    }

    public void StalkForPlayer(Transform player)
    {
        _player = player;
    }

    private void MoveAccordingToPattern()
    {
        Vector3 pos = Vector3.zero;

        switch (_movement)
        {
            case Movements.Linear:
                float distance = transform.position.x - _player.transform.position.x;
                if (Mathf.Abs(distance) >= 10f)
                    pos = transform.position + transform.right * distance * Speed * Time.deltaTime;
                else
                    pos = transform.position;
                break;
            case Movements.Circle:
                pos = GetComponent<EnemyCircleMovement>().GetPos(Speed);
                break;
            case Movements.ZigZag:
                pos = GetComponent<EnemyZigZagMovement>().GetPos(Speed);
                break;
        }
        _rb.MovePosition(pos);
    }

    private void FixedUpdate()
    {
        if (_player == null)
            return;

        MoveAccordingToPattern();


    }
}
