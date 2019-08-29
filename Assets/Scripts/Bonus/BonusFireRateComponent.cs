using UnityEngine;
using System;
using System.Collections;

//maybe do in future an abstract bonus conponent or interface for different types of bonuses 
// player shots faster
[Serializable]
public class BonusFireRateComponent : MonoBehaviour
{
    [SerializeField]
    private float _firerate;
    [SerializeField]
    private float _timeForEffect;
    public float GetFireRate()
    {
        return _firerate;
    }

    public float GetTime()
    {
        return _timeForEffect;
    }
}

