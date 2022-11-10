using UnityEngine;
using System;

public class Map : MonoBehaviour
{
    [SerializeField] private MapSizeConfig _mapSizeConfig;

    private MapSegmentBase[,] _segmentsRepository;

    private MapPointSegment _startPointSegment;
    private MapPointSegment _finalPointSegment;

    public MapPointSegment StartPointSegment => _startPointSegment;
    public MapPointSegment FinalPointSegment => _finalPointSegment;

    public MapSizeConfig MapSizeConfig => _mapSizeConfig;
    public MapSegmentBase[,] SegmentsRepository => _segmentsRepository;

    private void Awake()
    {
        Vector2Int size = _mapSizeConfig.Size;
        _segmentsRepository = new MapSegmentBase[size.x,size.y];
    }

    private void CheckPositionOnValid(Vector2Int position)
    {
        Vector2Int size = _mapSizeConfig.Size;
        if (position.x < 0 || position.y < 0 || position.x >= size.x || position.y >= size.y)
            throw new Exception("Going beyond the map array");
    }

    public void SetStartPointSegment(MapPointSegment mapPointSegment)
    {
        _startPointSegment = mapPointSegment;
    }

    public void SetFinalPointSegment(MapPointSegment mapPointSegment)
    {
        _finalPointSegment = mapPointSegment;
    }

    public Vector2Int GetSegmentRepositoryCoordinate(MapSegmentBase segment)
    {
        int size = _mapSizeConfig.SegmentSize;
        return new Vector2Int((int)(segment.transform.position.x/size), (int)(segment.transform.position.z / size));
    }

    public void SetMapSegment(MapSegmentBase segment, Vector2Int position)
    {
        CheckPositionOnValid(position);
        MapSegmentBase segmentInRepository = _segmentsRepository[position.x, position.y];
        if (segmentInRepository != null)
            Destroy(segmentInRepository);
        _segmentsRepository[position.x,position.y] = segment;
    }

    public MapSegmentBase GetMapSegment(Vector2Int position)
    {
        CheckPositionOnValid(position);
        return _segmentsRepository[position.x, position.y];
    }
}
