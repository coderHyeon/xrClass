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
                
                NavWaypoint[] path = waypointMng.PathFinding(null); //����� ���÷� ������ ����
                player.SetPath(path);
            }
            //������ ����?, ª�� �Ÿ� ��ȯ�� �޾Ƽ�? player�� �۵��ؾ���

        }
    }
}
