using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
