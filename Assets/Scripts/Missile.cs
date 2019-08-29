using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private SpaceObject _parent;

    public void SetParent(SpaceObject obj)
    {
        _parent = obj;
    }
    void OnTriggerEnter(Collider other)
    {
        SpaceObject obj = other.GetComponent<SpaceObject>();
        if (obj != null && _parent != null)
        {
            // if enemy strikes enemy or asteroid => do nothing
            if ( _parent.GetComponent<Enemy>() != null && (obj.GetComponent<Asteroid>() != null || obj.GetComponent<Enemy>() != null))
                return;
            obj.DamageMe(obj, _parent.DamageLevel);
            Destroy(gameObject);
        }
    }
}
