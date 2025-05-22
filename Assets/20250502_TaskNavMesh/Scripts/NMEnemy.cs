using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class NMEnemy : MonoBehaviour
{
    private NavMeshAgent monAgent = null;
    private bool isMoving = false;
    private WaitForSeconds wait5Sec = new WaitForSeconds(5f);
    public void Awake()
    {
        monAgent = GetComponent<NavMeshAgent>();


    }


    public void Update()
    {
       // Vector3 randomDirection = transform.position;
        if (/*transform.position == randomDirection ||*/ !isMoving)
        {
            Vector3  randomDirection = transform.position + Random.insideUnitSphere * 30f;
            randomDirection.y = 3f;
            RaycastHit hit;
            if (Physics.Raycast( transform.position, randomDirection, out hit))
            {
                // 픽킹 포인트가 네비메쉬 위에 있는지 검사
                NavMeshHit navHit;
                if (NavMesh.SamplePosition(hit.point, out navHit, 3f, NavMesh.AllAreas))
                {
                    monAgent.SetDestination(navHit.position);
                    isMoving = true;
                }
            }
        }

        if (isMoving && !monAgent.pathPending)
        {
            // 경로가 장애물로 막혀 있는지 검사
            NavMeshHit obstaclesHit;
            bool noObstacles = NavMesh.Raycast(transform.position, monAgent.destination, out obstaclesHit, NavMesh.AllAreas);

            // 장애물에 없다면 빨간색, 장애물에 가로막혔다면 파란색으로 표시
            Debug.DrawLine(
                monAgent.destination,
                monAgent.destination + (Vector3.up * 5f),
                noObstacles ? Color.red : Color.blue);

            if (monAgent.remainingDistance <= monAgent.stoppingDistance)
            {
                Debug.Log("Moving Done");
                isMoving = false;
            }
        }




    }

    public bool IsActive
    {
        get { return gameObject.activeSelf; }

    }
    public void SetActive(bool _isActive)
    {
        gameObject.SetActive(_isActive);
    }
}
