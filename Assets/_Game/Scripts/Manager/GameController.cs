using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    
    [SerializeField] private Transform pipeStartPos;
    [SerializeField] private BirdHandler birdHandler;
    [SerializeField] private PipeHandler pipeHandler;
    public enum GameState
    {
        StartGame = 0,
        PlayGame = 1,
        PauseGame = 2,
        EndGame = 3,
    }

    public GameState State;

    private int _score;
    
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    private void Update()
    {
        if (GameController.Instance.State != GameController.GameState.PlayGame)
            return;

        pipeHandler.SpawnPipe();
        birdHandler.Movement();
    }

    protected override void Init()
    {
        base.Init();
        Time.timeScale = 0f;
        State = GameState.StartGame;
    }

    public void CheckGameState()
    {
        switch (State)
        {
            case GameState.StartGame:
                break;
            case GameState.PlayGame:
                PlayGame();
                break;
            case GameState.PauseGame:
                break;
            case GameState.EndGame:
                EndGame();
                break;
        }
    }

    private void PlayGame()
    {
        Time.timeScale = 1f;
    }

    private void EndGame()
    {
        UIController.Instance.EndGame();
        StartCoroutine(ResetGame());
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(Constants.GameScene);
    }
}

