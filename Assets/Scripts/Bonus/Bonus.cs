using UnityEngine;
using System.Collections;
using System;

public class Bonus : MonoBehaviour
{
    private BonusAction _act;

    public void SetActionOnDestroy(BonusAction action)
    {
        _act = action;
    }

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            BonusController.instance.GetBonusAction(_act, gameObject);
            Destroy(gameObject);
        }
    }
}
