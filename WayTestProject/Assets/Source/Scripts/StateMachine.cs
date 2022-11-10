using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _activeState;
    [SerializeField] private UserPath _userPath;

    public State ActiveState => _activeState;

    public event Action StateChanged;

    private void Awake()
    {
        _userPath.PathEntered += SetGameState;
    }

    private void SetGameState()
    {
        SetActiveState(State.Game);
    }

    public void SetActiveState(State state)
    {
        _activeState = state;
        StateChanged?.Invoke();
    }
}
