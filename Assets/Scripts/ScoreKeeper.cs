using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreKeeper: MonoBehaviour
{
    private int _score;
    public void SetScore(int score)
    {
        _score = score;
    }

    public int GetScore()
    {
        return _score;
    }
}
