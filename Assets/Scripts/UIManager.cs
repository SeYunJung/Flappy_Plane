using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance {  get { return _instance; } }

    public TextMeshProUGUI uiLoseText;
    public TextMeshProUGUI uiScoreText;

    private void Awake()
    {
        _instance = this;
    }

    public void ShowLose()
    {
        uiLoseText.gameObject.SetActive(true);
    }

    public void SetScore(int currentScore)
    {
        uiScoreText.text = currentScore.ToString();
    }
}
