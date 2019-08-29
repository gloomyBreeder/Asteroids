using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : BasicManager<HUDController>
{
    [SerializeField]
    private Image _barHP;
    [SerializeField]
    private Button _pause;
    [SerializeField]
    private Text _score;

    private int _scoreCount;
    private float _playerHP;
    private float _currentPlayerHP;
    private bool _isPaused = false;
    void Start()
    {
        _barHP.fillAmount = 1f;
        _scoreCount = 0;
        _score.text = _scoreCount.ToString();
        _pause.onClick.AddListener(onPauseEvent);
    }

    void onPauseEvent()
    {
        if (!_isPaused)
        {
            PauseGame();
            _isPaused = true;
            _pause.GetComponentInChildren<Text>().text = "Resume";
        }
        else
        {
            ContinueGame();
            _isPaused = false;
            _pause.GetComponentInChildren<Text>().text = "Pause";
        }
            
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void SetPlayerHP(float hp)
    {
        _playerHP = hp;
    }

    public void AddScore(int score)
    {
        _scoreCount += score;
        _score.text = _scoreCount.ToString();
    }
    public void UpdatePlayerHP(float hp)
    {
        _currentPlayerHP = hp;
        if (_currentPlayerHP <= 0)
        {
            UpdateBarHP(0);
            return;
        }
        // get percentage of value
        float percentage = _currentPlayerHP / 100 * _playerHP;
        UpdateBarHP(percentage);
    }

    void UpdateBarHP(float updVal)
    {
        _barHP.fillAmount = updVal;
    }
}
