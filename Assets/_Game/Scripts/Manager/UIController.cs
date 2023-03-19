using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Singleton<UIController>
{
    [SerializeField] private MainMenuPnl mainMenuPnl;
    [SerializeField] private GamePnl playGamePnl;
    [SerializeField] private EndGamePnl endGamePnl;

    protected override void Init()
    {
        base.Init();
        StartGame();
    }

    public void Hide()
    {
        mainMenuPnl.gameObject.SetActive(false);
        playGamePnl.gameObject.SetActive(false);
        endGamePnl.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        Hide();
        mainMenuPnl.gameObject.SetActive(true);
        playGamePnl.UpdateScore(GameController.Instance.Score);
    }

    public void PlayGame()
    {
        Hide();
        playGamePnl.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        Hide();
        endGamePnl.gameObject.SetActive(true);
    }
}
