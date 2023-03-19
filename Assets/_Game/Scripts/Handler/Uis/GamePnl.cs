using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePnl : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private GameObject pausePnl;
    [SerializeField] private Button continueButton;

    public void UpdateScore(int value)
    {
        scoreTxt.text = value.ToString();
    }

    private void Awake()
    {
        pausePnl.SetActive(false);
        pauseBtn.onClick.AddListener(() =>
        {
            GameController.Instance.State = GameController.GameState.PauseGame;
            Time.timeScale = 0f;
            scoreTxt.gameObject.SetActive(false);
            pauseBtn.gameObject.SetActive(false);
            pausePnl.SetActive(true);
        });

        continueButton.onClick.AddListener(() =>
        {
            GameController.Instance.State = GameController.GameState.PlayGame;
            Time.timeScale = 1f;
            pausePnl.SetActive(false);
            scoreTxt.gameObject.SetActive(true);
            pauseBtn.gameObject.SetActive(true);
        });
    }
}
