using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   private int _score = 0;
   private TextMeshProUGUI _scoreText;
    void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();   
    }
    void Start()
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        _scoreText.text = "Score :" + _score;
    }
    public void incrementScore(int incrementScore)
    {
        _score += incrementScore;
        RefreshUI();
    }
}
