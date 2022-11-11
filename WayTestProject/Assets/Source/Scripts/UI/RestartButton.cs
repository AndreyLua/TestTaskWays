using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button _restartButton;

    public event Action RestartButtonClicked;

    private void Awake()
    {
        _restartButton = gameObject.GetComponent<Button>();
        _restartButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        RestartButtonClicked?.Invoke();
    }
}