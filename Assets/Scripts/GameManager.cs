using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates { countDown, running, raceOver};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    GameStates gameState = GameStates.countDown;

    public event Action<GameManager> OnGameStateChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void LevelStart()
    {
        gameState = GameStates.countDown;

        Debug.Log("Level started");
    }

    public GameStates GetGameState()
    {
        return gameState;
    }

    private void ChangeGameState(GameStates newGameState)
    {
        if (gameState != newGameState)
        {
            gameState = newGameState;

            OnGameStateChanged?.Invoke(this);
        }
    }

    public void OnRaceStart()
    {
        Debug.Log("OnRaceStart");

        ChangeGameState(GameStates.running);
    }
    public void OnRaceCompleted()
    {
        Debug.Log("OnRaceCompleted");

        ChangeGameState(GameStates.raceOver);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelStart();
    }
}
