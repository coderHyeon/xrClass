using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class NMPlayer : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private bool isMoving = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // ��ŷ ����Ʈ�� �׺�޽� ���� �ִ��� �˻�
                NavMeshHit navHit;
                if (NavMesh.SamplePosition(hit.point, out navHit, 1f, NavMesh.AllAreas))
                {
                    agent.SetDestination(navHit.position);
                    isMoving = true;
                }
            }
        }

        // ��� Ž���� �����ٸ�,
        if (isMoving && !agent.pathPending)
        {
            // ��ΰ� ��ֹ��� ���� �ִ��� �˻�
            NavMeshHit obstaclesHit;
            bool noObstacles = NavMesh.Raycast(transform.position, agent.destination, out obstaclesHit, NavMesh.AllAreas);

            // ��ֹ��� ���ٸ� ������, ��ֹ��� ���θ����ٸ� �Ķ������� ǥ��
            Debug.DrawLine(
                agent.destination,
                agent.destination + (Vector3.up * 5f),
                noObstacles ? Color.red : Color.blue);

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                Debug.Log("Moving Done");
                isMoving = false;
            }
        }
    }
}

	public class AgentController : MonoBehaviour
	{
	    public float updateInterval = 3f; // ��ǥ ��ġ�� ������ �ð� ���� (��)
	    private NavMeshAgent agent; // NavMeshAgent�� ������ ����
	    private float timeSinceLastUpdate; // ���������� ��ǥ ��ġ�� �����ߴ� �ð�
	 
	    void Start()
	    {
	        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent ������Ʈ�� �����ɴϴ�.
	        timeSinceLastUpdate = updateInterval; // �ʱ⿡ ��ǥ ��ġ�� �����ϱ� ���� �ð� ���� �����մϴ�.
	    }
	 
	    void Update()
	    {
	        timeSinceLastUpdate += Time.deltaTime; // �ð� ���� �����մϴ�.
	 
	        if (timeSinceLastUpdate >= updateInterval) // ������ �ð� ������ �������� Ȯ���մϴ�.
	        {
	            Vector3 randomPosition = GetRandomPositionOnNavMesh(); // NavMesh ���� ������ ��ġ�� �����ɴϴ�.
	            agent.SetDestination(randomPosition); // NavMeshAgent�� ��ǥ ��ġ�� ���� ��ġ�� �����մϴ�.
	            timeSinceLastUpdate = 0f; // �ð� ���� �ʱ�ȭ�մϴ�.
	        }
	    }
	 
	    Vector3 GetRandomPositionOnNavMesh()
	    {
	        Vector3 randomDirection = Random.insideUnitSphere * 20f; // ���ϴ� ���� ���� ������ ���� ���͸� �����մϴ�.
	        randomDirection += transform.position; // ���� ���� ���͸� ���� ��ġ�� ���մϴ�.
	 
	        NavMeshHit hit;
	        if (NavMesh.SamplePosition(randomDirection, out hit, 20f, NavMesh.AllAreas)) // ���� ��ġ�� NavMesh ���� �ִ��� Ȯ���մϴ�.
	        {
	            return hit.position; // NavMesh ���� ���� ��ġ�� ��ȯ�մϴ�.
	        }
	        else
	        {
	            return transform.position; // NavMesh ���� ���� ��ġ�� ã�� ���� ��� ���� ��ġ�� ��ȯ�մϴ�.
	        }
	    }
	}






