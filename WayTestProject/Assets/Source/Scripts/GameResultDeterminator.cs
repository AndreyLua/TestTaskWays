using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultDeterminator : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private PlayerMovableObject _playerMovableObject;
    [SerializeField] private AutomaticMovableObject _automaticMovableObject;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _playerMovableObject.Finished += PlayerWin;
        _automaticMovableObject.Finished += PlayerLost;
    }

    private void PlayerWin()
    {
        _scoreCounter.AddScore(10);
        _stateMachine.SetActiveState(State.BeginGame);
    }

    private void PlayerLost()
    {
        _stateMachine.SetActiveState(State.BeginGame);
    }

}
