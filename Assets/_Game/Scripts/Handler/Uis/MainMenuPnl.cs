using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPnl : MonoBehaviour
{
    [SerializeField] private Button startGameBtn;

    private void Awake()
    {
        startGameBtn.onClick.AddListener(() =>
        {
            GameController.Instance.State = GameController.GameState.PlayGame;
            GameController.Instance.CheckGameState();
            UIController.Instance.PlayGame();
        });
    }
}
