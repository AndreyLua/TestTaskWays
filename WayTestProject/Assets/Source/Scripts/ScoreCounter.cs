using System;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private GameObject _scoreTextObject;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;

    public int Score => _score;

    private void Awake()
    {
        SetText();
    }

    private void SetText()
    {
        _scoreText.text = "Score:" + _score.ToString();
    }

    public void AddScore(int value)
    {
        if (value < 0)
            throw new Exception("The value of points cannot be negative");

        _score += value;
        SetText();
    }
}
