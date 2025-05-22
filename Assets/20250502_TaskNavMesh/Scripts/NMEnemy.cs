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
                // ��ŷ ����Ʈ�� �׺�޽� ���� �ִ��� �˻�
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
            // ��ΰ� ��ֹ��� ���� �ִ��� �˻�
            NavMeshHit obstaclesHit;
            bool noObstacles = NavMesh.Raycast(transform.position, monAgent.destination, out obstaclesHit, NavMesh.AllAreas);

            // ��ֹ��� ���ٸ� ������, ��ֹ��� ���θ����ٸ� �Ķ������� ǥ��
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
