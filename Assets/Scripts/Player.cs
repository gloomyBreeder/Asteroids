using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SpaceObject
{
    public override float Health { get; set; }
    public override float DamageLevel { get; set; }
    public override float Speed { get => _speed; set => _speed = value; }

    [SerializeField]
    private float _health;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Renderer _renderer;
    [SerializeField]
    private Shotable _shotable;

    private Vector3 _bounds;
    private Rigidbody _rb;
    private float _width;
    private float _maxHealth;

    private Coroutine _actionCoroutine;

    void Start()
    {
        Health = _health;
        _maxHealth = _health;
        HUDController.instance.SetPlayerHP(_health);
        DamageLevel = _damage;
        _bounds = BoundariesController.instance.ScreenBoundaries;
        _rb = GetComponent<Rigidbody>();
        _width = _renderer.bounds.extents.x;
        _shotable.OldRate = _shotable.FireRate;
    }

    void Update()
    {
        if (!MainMenuController.instance.IsPlaying)
            return;

        if (Input.GetMouseButtonDown(0) && Time.time > _shotable.NextFire)
        {
            _shotable.NextFire = Time.time + _shotable.FireRate;
            Attack(this, _shotable.BulletPrefab, _shotable.ShotSpawns);
        }

        // keep player inside boundaries
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _bounds.x * -1 + _width, _bounds.x - _width);
        transform.position = viewPos;
    }

    void FixedUpdate()
    {
        if (!MainMenuController.instance.IsPlaying)
            return;

        float move = Input.GetAxis("Horizontal");
        _rb.MovePosition(transform.position + transform.right * move * _speed);
    }

    public void UpdateHP(float hp, bool increase = true)
    {
        // we can increase and decrease (maybe in future) hp by bonus
        if (increase)
        {
            Health += hp;
            if (Health > _maxHealth)
                Health = _maxHealth;
        }
        else
            DamageMe(this, hp);
    }
    public void UpdateFireRate(float rate, float time)
    {
        float oldRate = _shotable.OldRate;
        _shotable.FireRate = rate;

        //if coroutine is playing stop it
        // it's not very good solution if we should have > 1 coroutine
        if (_actionCoroutine != null)
            StopCoroutine(_actionCoroutine);

        _actionCoroutine = StartCoroutine(UpdateFireRateCoroutine(oldRate, time));
        
    }

    private IEnumerator UpdateFireRateCoroutine(float rate, float time)
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            --time;
        }
        _shotable.FireRate = rate;
    }


}
