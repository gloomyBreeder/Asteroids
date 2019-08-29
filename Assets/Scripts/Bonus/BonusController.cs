using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : BasicManager<BonusController>
{
    [SerializeField]
    private List<BonusSettings> _bonuses = new List<BonusSettings>();
    [SerializeField]
    private float _spawnTime;
    [SerializeField]
    private List<Transform> _spawnPoints;
    [SerializeField]
    private Player _player;

    public void StartSpawnBonuses()
    {
        StartCoroutine(Spawner.instance.SpawnBonus(_bonuses, _spawnPoints, _spawnTime));
    }

    public void GetBonusAction(BonusAction action, GameObject bonus)
    {
        switch (action)
        {
            case BonusAction.Heal:
                HealPlayer(bonus);
                break;
            case BonusAction.IncreaseFireRate:
                IncreaseFireRate(bonus);
                break;
        }
    }

    public void HealPlayer(GameObject bonus)
    {
        BonusHealthComponent healthComp = bonus.GetComponent<BonusHealthComponent>();
        if (healthComp != null)
        {
            _player.UpdateHP(healthComp.GetHP());
            HUDController.instance.UpdatePlayerHP(_player.Health);
        }
    }

    public void IncreaseFireRate(GameObject bonus)
    {
        BonusFireRateComponent fireRateComp = bonus.GetComponent<BonusFireRateComponent>();
        if (fireRateComp != null)
        {
            _player.UpdateFireRate(fireRateComp.GetFireRate(), fireRateComp.GetTime());
        }
    }

    
}
