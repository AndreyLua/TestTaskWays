using UnityEngine;

public class MapSegmentFreeFactory : MapSegmentFaсtoryBehaviorBase
{
    [SerializeField] private MapSegmentBehaviourTypeConfig _mapSegmentBehaviourTypeConfig;

    public override MapSegmentType Type => MapSegmentType.Free;
    public override TMapSegment Create<TMapSegment>(Vector2 position)
    {
        TMapSegment mapSegmentBase = (TMapSegment)_mapSegmentBehaviourTypeConfig.MapSegmentsBehaviourTypePairs[Type];
        TMapSegment mapSegmentPrefab = Instantiate<TMapSegment>(mapSegmentBase, new Vector3(position.x, 0,position.y), Quaternion.identity);
        return mapSegmentPrefab;
    }
}