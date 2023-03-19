using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    public static  readonly string GameScene = "Game";
    public enum GameState
    {
        StartGame = 0,
        PlayGame = 1,
        PauseGame = 2,
        EndGame = 3,
    }
    public Bird bird;

    public GameState State;

    private int _score;
    
    public int Score
    {
        get { return _score; }
        private set { _score = value; }
    }


    protected override void Init()
    {
        base.Init();
        Time.timeScale = 0f;
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(GameScene);
    }

    public void EndGame()
    {
        if(bird.IsDead)
        {
            UIController.Instance.EndGame();
        }
        StartCoroutine(ResetGame());
    }
}

