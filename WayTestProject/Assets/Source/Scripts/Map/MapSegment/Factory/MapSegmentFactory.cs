using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapSegmentFactory : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private MapSegmentFaсtoryBehaviorBase[] _factories;

    private Dictionary<MapSegmentType, MapSegmentFaсtoryBehaviorBase> _mapSegmentFactoryBehaviourTypePairs;

    private void Awake()
    {
        _mapSegmentFactoryBehaviourTypePairs = _factories.ToDictionary(mapSegmentFactory => mapSegmentFactory.Type, mapSegmentFactory => mapSegmentFactory);
    }

    public TMapSegment Create<TMapSegment>(MapSegmentType MapSegmentType, Vector2 position) where TMapSegment : MapSegmentBase
    {
        MapSegmentFaсtoryBehaviorBase factoryBehavior = _mapSegmentFactoryBehaviourTypePairs[MapSegmentType];
        TMapSegment mapSegment = factoryBehavior.Create<TMapSegment>(position);
        mapSegment.transform.parent = _map.transform;
        return mapSegment;
    }
}
