using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollowPath : MonoBehaviour
{
    public PathDefinition path;
    public float MoveSpeed = 1f;
    private Transform _TargetPoint;
    void Start()
    {
        if (path == null)
            return;
        _TargetPoint = path.getPointAt(0);
    }
    void Update()
    {
        if (path == null)
            return;
        transform.position = Vector2.MoveTowards(transform.position, _TargetPoint.position,
        MoveSpeed * Time.deltaTime);
        float Distance = Vector2.Distance(transform.position, _TargetPoint.position);
        if (Distance <= 0.1f)
            _TargetPoint = path.getNextPoint();
    }
}
