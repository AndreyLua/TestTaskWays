using UnityEngine;

public class AutomaticMovableObject : MovableObject
{
    [SerializeField] private PathGenerator _pathGenerator;

    private PathData _path;
    private Map _map;

    private void Start()
    {
        _path = _pathGenerator.GetGeneratedPath();
        _map = _pathGenerator.Map;
        SetNextSegmentPosition(_map.GetSegmentRepositoryCoordinate(_map.StartPointSegment));
    }

    private void Update()
    {
        Move(_path, _map.MapSizeConfig.SegmentSize, _map.GetSegmentRepositoryCoordinate(_map.FinalPointSegment));
    }

    public void Restart()
    {
        _path = _pathGenerator.GetGeneratedPath();
        _map = _pathGenerator.Map;
        SetNextSegmentPosition(_map.GetSegmentRepositoryCoordinate(_map.StartPointSegment));
    }
}
