using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private MapSegmentFactory _factory;

    private void Awake()
    {
        Vector2Int mapSize = _map.MapSizeConfig.Size;
        int segmentSize = _map.MapSizeConfig.SegmentSize;
        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
                if (i > mapSize.x / 2 && j > mapSize.y / 2)
                {
                    MapSegmentBase segment = _factory.Create<MapBarrierSegment>(MapSegmentType.Barrier, new Vector2(i * segmentSize, j * segmentSize));
                    _map.SetMapSegment(segment,new Vector2Int(i,j));
                }
                else
                {
                    MapSegmentBase segment = _factory.Create<MapFreeSegment>(MapSegmentType.Free, new Vector2(i * segmentSize, j * segmentSize));
                    _map.SetMapSegment(segment, new Vector2Int(i, j));
                }
            }
        }

        _map.SetStartPointSegment(CreatePointSegment(0, 0));
        _map.SetFinalPointSegment(CreatePointSegment(5, 9));
    }

    private MapPointSegment CreatePointSegment(int i, int j)
    {
        int segmentSize = _map.MapSizeConfig.SegmentSize;
        MapPointSegment pointSegment = _factory.Create<MapPointSegment>(MapSegmentType.Point, new Vector2(i* segmentSize, j* segmentSize));
        _map.SetMapSegment(pointSegment, new Vector2Int(i, j));
        return pointSegment;
    }
}
