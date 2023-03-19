using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGamePnl : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    public void OnEnable()
    {
        scoreTxt.text = "Score: " + GameController.Instance.Score;
    }
}
