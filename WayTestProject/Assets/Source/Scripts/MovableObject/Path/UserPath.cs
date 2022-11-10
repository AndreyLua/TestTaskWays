using System;
using UnityEngine;

public class UserPath : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Map _map;

    private LineRenderer _lineRender;
    private PathData _path;
    private Vector2Int _lastElementPathData;

    public PathData Path => _path;

    public event Action PathEntered;

    private void Awake()
    {
        _lineRender = gameObject.GetComponent<LineRenderer>();
        _path = new PathData();
    }

    private void Start()
    {
        Vector2Int segment = _map.GetSegmentRepositoryCoordinate(_map.StartPointSegment);
        _path.AddNewPoint(segment);
        _lastElementPathData = segment;
    }

    private void Update()
    {
        if (_stateMachine.ActiveState == State.BeginGame)
        {
            RecordPath();
            DrawPath();
        }
    }

    private void RecordPath()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                MapSegmentBase freeMapSegment = hitInfo.collider.gameObject.GetComponent<MapFreeSegment>();
                MapPointSegment pointMapSegment = hitInfo.collider.gameObject.GetComponent<MapPointSegment>();

                if (pointMapSegment != null && pointMapSegment == _map.FinalPointSegment)
                {
                    Vector2Int segmentPosition = _map.GetSegmentRepositoryCoordinate(pointMapSegment);
                    if (IsNeighboringPoint(segmentPosition))
                    {
                        _path.AddNewPoint(segmentPosition);
                        PathEntered?.Invoke();
                        return;
                    }
                }

                if (freeMapSegment != null)
                {
                    Vector2Int segmentPosition = _map.GetSegmentRepositoryCoordinate(freeMapSegment);
                    if (IsNeighboringPoint(segmentPosition))
                        if (!_path.PathPoints.Contains(segmentPosition))
                        {
                            _lastElementPathData = segmentPosition;
                            _path.AddNewPoint(segmentPosition);
                        }
                }
            }
        }
    }

    private bool IsNeighboringPoint(Vector2Int point)
    {
        Vector2Int difference = (_lastElementPathData - point);
        return ((Mathf.Abs(difference.x) <= 1 && difference.y==0)||(Mathf.Abs(difference.y) <= 1 && difference.x == 0));
    }


    private void DrawPath()
    { 
        Vector2Int[] drawPoints = _path.GetArrayPoints();
        Vector3[] positions = new Vector3[_path.PathPoints.Count];
        _lineRender.positionCount = _path.PathPoints.Count;
        for (int i =0; i < _path.PathPoints.Count; i++)
        {
            positions[i] = new Vector3(drawPoints[i].x,0.2f, drawPoints[i].y); 
        }
        _lineRender.SetPositions(positions);
    }
}
