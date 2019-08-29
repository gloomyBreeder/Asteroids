using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceObject : MonoBehaviour
{
    [HideInInspector]
    public abstract float Health { get; set; }
    [HideInInspector]
    public abstract float DamageLevel { get; set; }
    [HideInInspector]
    public abstract float Speed { get; set; }

    public void DamageMe(SpaceObject victim, float damage)
    {
        Debug.Log("damage to " + victim.gameObject.name + damage);
        victim.Health -= damage;
        Debug.Log(victim.gameObject.name + " health is " + victim.Health);
        CheckDeath(victim);

        //set player hp in hud
        if (victim.GetComponent<Player>() != null)
            HUDController.instance.UpdatePlayerHP(victim.Health);
    }

    public void Attack(SpaceObject obj, GameObject bull, List<Transform> spawns)
    {
        // attack from all weapons
        foreach (var spawn in spawns)
        {
            GameObject bullet = Instantiate(bull, spawn.position, spawn.rotation);
            Missile missile = bullet.GetComponent<Missile>();
            missile.SetParent(obj);
        }
    }

    public virtual void CheckDeath(SpaceObject victim)
    {
        if (victim.Health <= 0)
        {
            ScoreKeeper score = victim.GetComponent<ScoreKeeper>();
            if (score != null)
            {
                HUDController.instance.AddScore(score.GetScore());
            }
            if (victim.GetComponent<Player>() != null)
                MainMenuController.instance.GameOver();
            DestroyObject(victim.gameObject);
        }
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
