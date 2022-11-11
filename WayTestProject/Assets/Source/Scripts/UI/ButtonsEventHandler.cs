using UnityEngine;

public class ButtonsEventHandler : MonoBehaviour
{
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private ResumeButton _resumeButton;
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private StateMachine _stateMachine;

    [SerializeField] private Map _map;
    [SerializeField] private AutomaticMovableObject _automaticMovableObject;
    [SerializeField] private PlayerMovableObject _playerMovableObject;
    [SerializeField] private UserPath _userPath;

    private void Awake()
    {
        _pauseButton.PauseButtonClicked += SetPauseState;
        _resumeButton.ResumeButtonClicked += SetGameState;
        _restartButton.RestartButtonClicked += RestartGame;
    }

    private void RestartGame()
    {
        Vector3 startPositon = _map.StartPointSegment.transform.position;
        _playerMovableObject.Restart();
        _automaticMovableObject.Restart();
        _automaticMovableObject.transform.position = startPositon;
        _playerMovableObject.transform.position = startPositon;
        _stateMachine.SetActiveState(State.BeginGame);
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
