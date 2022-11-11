using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [SerializeField] private State _state;
    public State State => _state;
}