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
        if (Input.GetMouseButtonDown(0)) //네브메쉬가 아닌곳을 못가도록
        {
            //{
            //    Vector3 mousePos = Input.mousePosition;
            //    Ray ray = Camera.main.ScreenPointToRay(mousePos);
            //    //RaycastHit hit; 가아닌
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

                agent.destination = hit.point; //목적지가 히트 포인트
            }
            //agent.remainingDistance 목적지까지의 거리
            //agent.stoppingDistance 목적지까지의 대충의 거리를 지정할 수 있음



        }
    }

    }


