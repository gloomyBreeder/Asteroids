using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZagMovement : MonoBehaviour
{
    private float _angle = 0f;
    [SerializeField]
    private float _amplitude = 40f;

    public Vector3 GetPos(float speed)
    {
        Vector3 pos = new Vector3(_amplitude * Mathf.Cos(_angle), speed * Time.deltaTime, 0f);
        _angle += Time.deltaTime;
        return new Vector3(pos.x, transform.position.y, _angle);
    }
}
