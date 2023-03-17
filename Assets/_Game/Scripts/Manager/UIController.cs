using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private MainMenuPnl mainMenuPnl;
    [SerializeField] private GamePnl gamePnl;
    [SerializeField] private EndGamePnl endGamePnl;

    private void Hide()
    {
        mainMenuPnl.gameObject.SetActive(false);
        gamePnl.gameObject.SetActive(false);
        endGamePnl.gameObject.SetActive(false);
    }
}
