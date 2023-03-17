using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public enum GameState
    {
        StartGame = 0,
        PlayGame = 1,
        PauseGame = 2,
        EndGame = 3,
    }
}

