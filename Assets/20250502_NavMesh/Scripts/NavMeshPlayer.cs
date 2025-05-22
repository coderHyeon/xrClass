using UnityEngine;
using UnityEngine.AI;

public class NavMeshPlayer : MonoBehaviour
{
    private NavMeshAgent agent = null;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //�׺�޽��� �ƴѰ��� ��������
        {
            //{
            //    Vector3 mousePos = Input.mousePosition;
            //    Ray ray = Camera.main.ScreenPointToRay(mousePos);
            //    //RaycastHit hit; ���ƴ�
            //    NavMeshHit hit;
            //    if(NavMesh.Raycast(
            //        ray.origin, ray.direction *100f,
            //        out hit,
            //        NavMesh.AllAreas
            //        ))
            //    {
            //        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            //    }

            RaycastHit hit;
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

                agent.destination = hit.point; //�������� ��Ʈ ����Ʈ
            }
            //agent.remainingDistance ������������ �Ÿ�
            //agent.stoppingDistance ������������ ������ �Ÿ��� ������ �� ����



        }
    }

    }


