using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesController : BasicManager<BoundariesController>
{
    [SerializeField]
    private Camera _cam;
    private BoxCollider _collider;

    public Vector3 ScreenBoundaries
    {
        get => _cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _cam.transform.position.z));
    }

    override public void Awake()
    {
        base.Awake();
        _collider = GetComponent<BoxCollider>();

        // get width and height of orthographic camera to set collider bounds
        float height = 2f * _cam.orthographicSize;
        float width = height * _cam.aspect;
        _collider.size = new Vector3(width, height, _collider.size.z);
    }

    private void OnTriggerExit(Collider other)
    {
        Movable movable = other.GetComponent<Movable>();
        if (movable != null)
        {
            movable.Destroy();
        }
    }

}
