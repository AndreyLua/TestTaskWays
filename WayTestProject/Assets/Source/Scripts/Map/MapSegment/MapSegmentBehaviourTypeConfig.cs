using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "MapSegmentBehaviourTypeConfig", menuName = "Config/Map/MapSegmentBehaviourTypeConfig")]
public class MapSegmentBehaviourTypeConfig : ScriptableObject
{
    [SerializeField] private MapSegmentBase[] _mapSegments;
    private Dictionary<MapSegmentType, MapSegmentBase> _mapSegmentsBehaviourTypePairs;
    public Dictionary<MapSegmentType, MapSegmentBase> MapSegmentsBehaviourTypePairs => _mapSegmentsBehaviourTypePairs;

    private void OnEnable()
    {
        _mapSegmentsBehaviourTypePairs = _mapSegments.ToDictionary(mapSegment => mapSegment.Type, mapSegment => mapSegment);
    }
}
