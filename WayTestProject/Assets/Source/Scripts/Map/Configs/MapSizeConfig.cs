using UnityEngine;

[CreateAssetMenu(fileName = "MapSizeConfig", menuName = "Config/Map/MapSizeConfig")]
public class MapSizeConfig : ScriptableObject
{
    [SerializeField] private Vector2Int _size;
    [SerializeField] private int _segmentSize;

    public Vector2Int Size => _size;
    public int SegmentSize => _segmentSize;
}

