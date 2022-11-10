using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    [SerializeField] private Map _map;

    public Map Map => _map;

    public PathData GetGeneratedPath()
    {
        Vector2Int startPosition = _map.GetSegmentRepositoryCoordinate(_map.StartPointSegment);
        Vector2Int finalPosition = _map.GetSegmentRepositoryCoordinate(_map.FinalPointSegment);
        Vector2Int nextPointPosition = startPosition;

        Vector2Int mapSize = _map.MapSizeConfig.Size;
        PathData path = new PathData();
    
        for(int i=0;i< mapSize.x; i++)
        {
            if (nextPointPosition.x + 1 > finalPosition.x || _map.GetMapSegment(nextPointPosition + new Vector2Int(1, 0)).Type == MapSegmentType.Barrier)
                break;
            nextPointPosition = nextPointPosition + new Vector2Int(1, 0);
            path.AddNewPoint(nextPointPosition);
        }

        for (int i = 0; i < mapSize.y; i++)
        {
            if (nextPointPosition.y + 1 > finalPosition.y || _map.GetMapSegment(nextPointPosition + new Vector2Int(0, 1)).Type == MapSegmentType.Barrier)
                break;
            nextPointPosition = nextPointPosition + new Vector2Int(0, 1);
            path.AddNewPoint(nextPointPosition);
        }

        return path;
    }
}

