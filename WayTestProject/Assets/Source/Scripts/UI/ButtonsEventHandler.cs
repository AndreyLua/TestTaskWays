using UnityEngine;

public class ButtonsEventHandler : MonoBehaviour
{
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private ResumeButton _resumeButton;
    [SerializeField] private StateMachine _stateMachine;

    private void Awake()
    {
        _pauseButton.PauseButtonClicked += SetPauseState;
        _resumeButton.ResumeButtonClicked += SetGameState;
    }

    private void SetPauseState()
    {
        _stateMachine.SetActiveState(State.Pause);
    }

    private void SetGameState()
    {
        _stateMachine.SetActiveState(State.Game);
    }
}
