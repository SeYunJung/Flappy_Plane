using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {  get { return _instance; } }

    private UIManager uiManager;

    public int currentScore = 0; 
    public int score = 1;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        uiManager = UIManager.Instance;
    }

    public void Win()
    {
        Debug.Log("�¸�!");
    }

    public void Lose()
    {
        Debug.Log("�й�!");
        uiManager.ShowLose();
    }

    public void AddScore()
    {
        currentScore += score;
        uiManager.SetScore(currentScore);
    }
}
