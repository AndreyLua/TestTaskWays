using System;
using System.Collections.Generic;
using UnityEngine;

public class PathData
{
    private Queue<Vector2Int> _pathPoints;

    public Queue<Vector2Int> PathPoints => _pathPoints;

    public PathData()
    {
        _pathPoints = new Queue<Vector2Int>();
    }

    public void AddNewPoint(Vector2Int position)
    {
        if (!_pathPoints.Contains(position))
            _pathPoints.Enqueue(position);
    }

    public Vector2Int[] GetArrayPoints()
    {
        return _pathPoints.ToArray();
    }

    public Vector2Int PopNextPoint()
    {
        if (_pathPoints.Count != 0)
        {
            return _pathPoints.Dequeue();
        }
        else
        {
            throw new Exception("Path points count = 0");
        }
    }
}

