using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleMovement : MonoBehaviour
{
    private float _angle = 0f;
    [SerializeField]
    private float _radius = 30f;

    public Vector3 GetPos(float speed)
    {
        _angle += Time.deltaTime;

        var x = Mathf.Cos(_angle * speed) * _radius;
        var z = Mathf.Sin(_angle * speed) * _radius;

        return new Vector3(x, transform.position.y, z);
    }
}
