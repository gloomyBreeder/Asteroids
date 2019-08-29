using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class MainMenuController : BasicManager<MainMenuController>
{
    [SerializeField]
    private Button _play;
    [SerializeField]
    private Button _exit;
    [SerializeField]
    private Canvas _canvas;
    [HideInInspector]
    public bool IsPlaying { get; private set; }

    void Start()
    {
        _play.onClick.AddListener(onPlayEvent);
        _exit.onClick.AddListener(onExitEvent);
    }

    // start game
    void onPlayEvent()
    {
        IsPlaying = true;
        EnemySpawner.instance.StartSpawnEnemies();
        AsteroidSpawner.instance.StartSpawnAsteroids();
        BonusController.instance.StartSpawnBonuses();
        _canvas.gameObject.SetActive(false);
    }

    void onExitEvent()
    {
        GameOver();
    }

    public void GameOver()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
