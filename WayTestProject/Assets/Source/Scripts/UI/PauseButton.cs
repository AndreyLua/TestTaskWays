using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button _pauseButton;

    public event Action PauseButtonClicked;

    private void Awake()
    {
        _pauseButton = gameObject.GetComponent<Button>();
        _pauseButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        PauseButtonClicked?.Invoke();
    }
}