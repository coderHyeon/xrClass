using UnityEngine;

public class NavNavigationManager : MonoBehaviour
{
    [SerializeField] private NavPlayer player = null;
    [SerializeField] private NavWaypointManager waypointMng = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player.IsMoving()) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                
                NavWaypoint[] path = waypointMng.PathFinding(null); //현재는 예시로 정해져 있음
                player.SetPath(path);
            }
            //실제로 보간?, 짧은 거리 반환을 받아서? player가 작동해야하

        }
    }
}
