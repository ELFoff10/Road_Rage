using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointNode : MonoBehaviour
{
    [Header("This is the waypoint we are going towards, not yet reached")]
    public float minDistanceToReachWayPoint = 5;

    public WayPointNode[] NextWayPointNode;
}
