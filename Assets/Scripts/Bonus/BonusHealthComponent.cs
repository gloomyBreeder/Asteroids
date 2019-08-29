using UnityEngine;
using System;
using System.Collections;

//maybe do in future an abstract bonus conponent or interface for different types of bonuses 
[Serializable]
public class BonusHealthComponent : MonoBehaviour
{
    [SerializeField]
    private float _hp;

    public float GetHP()
    {
        return _hp;
    }
}
