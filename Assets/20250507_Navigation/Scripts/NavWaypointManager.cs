using UnityEngine;

public class NavWaypointManager : MonoBehaviour
{
    private NavWaypoint startWaypoint = null;
    private NavWaypoint[] waypoints = null;
    private NavWaypoint[] nextWaypoints = null;

    //예시
    [SerializeField] private NavWaypoint[] pathExamples = null;

    private void Awake()
    {
        startWaypoint = GetComponentInChildren<NavWaypoint>();
        waypoints = GetComponentsInChildren<NavWaypoint>();
        nextWaypoints = GetComponentsInChildren<NavWaypoint>();
    }

    private void Start()
    {
        startWaypoint.transform.localScale= Vector3.one * 2;
    }

    public NavWaypoint[] PathFinding(NavWaypoint _destination)
    {
        ResetWaypointsStateAll();
        
        // 경로 찾기
        SetWaypointsStateCheck(pathExamples);

        return pathExamples;
    }

    private void ResetWaypointsStateAll()
    {
        foreach (NavWaypoint waypoint in waypoints)
            waypoint.SetState(NavWaypoint.Estate.Normal);
    }

    private void SetWaypointsStateCheck(NavWaypoint[] _path)
    {
        foreach (NavWaypoint waypoint in _path)
            waypoint.SetState(NavWaypoint.Estate.Check);
    }
}
