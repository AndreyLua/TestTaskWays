using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [SerializeField] private State _state;
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private ResumeButton _resumeButton;


    public State State => _state;
}
