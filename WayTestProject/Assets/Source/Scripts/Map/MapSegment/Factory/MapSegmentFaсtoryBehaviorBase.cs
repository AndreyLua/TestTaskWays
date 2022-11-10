using UnityEngine;

public abstract class MapSegmentFaсtoryBehaviorBase : MonoBehaviour
{
    public abstract MapSegmentType Type { get; }
    public abstract TMapSegment Create<TMapSegment>(Vector2 position) where TMapSegment : MapSegmentBase;
}
