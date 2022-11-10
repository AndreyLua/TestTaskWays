using UnityEngine;

public class ScreenRepository : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private UIScreen[] _screens;
    [SerializeField] private UserPath _userPath;
    private void Awake()
    {
        UpdateScreen();
        _stateMachine.StateChanged += UpdateScreen;
    }

    public void UpdateScreen()
    {
        foreach (UIScreen screen in _screens)
            screen.gameObject.SetActive(_stateMachine.ActiveState == screen.State);
    }
}
