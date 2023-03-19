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
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;
        });
    }
}
