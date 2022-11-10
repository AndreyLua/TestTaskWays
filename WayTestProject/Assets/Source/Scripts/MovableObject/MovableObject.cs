using System;
using UnityEngine;

public abstract class MovableObject : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private float _speed;

    private Vector2Int _nextSegmentPosition;

    public event Action Finished;


    public void SetNextSegmentPosition(Vector2Int position)
    {
        _nextSegmentPosition = position;
    }

    public void Move(PathData path, int segmentSize, Vector2Int finalCoordinate)
    {
        if (_stateMachine.ActiveState == State.Game)
        {
            Vector2Int coordinateInMapRepositiory = new Vector2Int(Mathf.RoundToInt(transform.position.x / segmentSize), Mathf.RoundToInt(transform.position.z / segmentSize));
            if (coordinateInMapRepositiory != finalCoordinate)
            {
                if (coordinateInMapRepositiory == _nextSegmentPosition)
                    _nextSegmentPosition = path.PopNextPoint() * segmentSize;

                Vector3 offset = (new Vector3(_nextSegmentPosition.x * segmentSize, 0, _nextSegmentPosition.y * segmentSize) - transform.position).normalized;
                transform.position += offset * _speed * Time.deltaTime;
            }
            else
            {
                Finished?.Invoke();
            }
        }
    }
}