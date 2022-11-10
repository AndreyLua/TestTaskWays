using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapSegmentBase : MonoBehaviour
{
    [SerializeField] private GameObject _skin;

    public GameObject Skin => _skin;
    public abstract MapSegmentType Type { get; }
}
