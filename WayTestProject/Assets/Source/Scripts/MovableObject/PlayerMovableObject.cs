using UnityEngine;

public class PlayerMovableObject : MovableObject
{
    [SerializeField] private UserPath _userPath;
    [SerializeField] private Map _map;

    private PathData _path;

    private void Awake()
    {
        _userPath.PathEntered += SetPath;
    }

    private void SetPath()
    {
        _path = _userPath.Path;
    }

    private void Start()
    {
        SetNextSegmentPosition(_map.GetSegmentRepositoryCoordinate(_map.StartPointSegment));
    }

    private void Update()
    {
        Move(_path, _map.MapSizeConfig.SegmentSize, _map.GetSegmentRepositoryCoordinate(_map.FinalPointSegment));
    }

    public void Restart()
    {
        _userPath.Restart();
        SetPath();
        SetNextSegmentPosition(_map.GetSegmentRepositoryCoordinate(_map.StartPointSegment));
    }    
}
