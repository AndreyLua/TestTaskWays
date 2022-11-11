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
            Vector2Int coordinateInMapRepositiory = new Vector2Int(Mathf.FloorToInt((transform.position.x / segmentSize)+0.05f), Mathf.FloorToInt((transform.position.z / segmentSize) + 0.05f));
            if (coordinateInMapRepositiory != finalCoordinate)
            {
                if (coordinateInMapRepositiory == _nextSegmentPosition)
                    _nextSegmentPosition = path.PopNextPoint() * segmentSize;

                Vector3 offset = (new Vector3(_nextSegmentPosition.x * segmentSize, 0, _nextSegmentPosition.y * segmentSize) - new Vector3(transform.position.x, 0, transform.position.z)).normalized;
                transform.position += offset * _speed * Time.deltaTime;
            }
            else
            {
                Finished?.Invoke();
            }
        }
    }
}