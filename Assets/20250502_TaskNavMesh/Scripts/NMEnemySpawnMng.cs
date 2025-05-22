using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;



public class NMEnemySpawnMng : MonoBehaviour
{
    [SerializeField] private int enemyCnt = 10;
    private GameObject enemyPrefab;
    public List<NMEnemy> enemyCountList = new List<NMEnemy>();
    private NavMeshAgent monAgent = null;
    private GameObject groundGb = null;

    [SerializeField] private float groundXRange = 0;

    public void Init()
    {
        EnemyCountInit();
    }

    private void Awake()
    {

        //enemyPrefab = Resources.Load<GameObject>("Prefabs\\NMEnemy");
        groundGb = GameObject.Find("Floor");
        groundXRange = groundGb.transform.localScale.x;
        
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        monAgent = GetComponent<NavMeshAgent>();

    }

    //�ʿ��� ��ü �и�
    //enemy setActive�� ���� �����ϵ�����

    // public Vector3 EnemyStartPos
    // Instatiate�� ��ġ�� �־���ϴµ� navMesh �˻絵 �ʿ�
    // 
    
    //����

    public void EnemyCountInit()
    {

        enemyPrefab = Resources.Load<GameObject>("Prefabs\\NMEnemy");
        //Transform enemyTr = enemyPrefab.transform;

        for (int i = 0; i < enemyCnt; i++) 
        { 
            
            Vector3 Random = StartPosRandMon();
            NavMeshHit obstaclesHit; 
            bool noObstacles = NavMesh.Raycast(transform.position, Random, out obstaclesHit, NavMesh.AllAreas);
            if (noObstacles)
            {
                GameObject enemyGo = Instantiate(enemyPrefab);
                enemyGo.name = $"����� ����? - {i}";
                // enemyGo.transform.localPosition = obstaclesHit.position;
                enemyGo.transform.localPosition = Random;
                enemyGo.transform.SetParent(transform);
                enemyCountList.Add(enemyGo.GetComponent<NMEnemy>());
            }
            else if (!noObstacles)
            {
                --i;
            }
        }
    }


    //���� ��ġ�Լ�
    public Vector3 StartPosRandMon()
    {

        Vector3 randomDirection = Vector3.zero + Random.insideUnitSphere * (groundXRange * 0.5f);
        randomDirection.y = 3f;

        Debug.Log("groundX : " + groundXRange);
        Debug.Log("randomDirection  x y z: " + randomDirection.x+"___" + randomDirection.y + "___" + randomDirection.z);
        return randomDirection;
    }



    //������ ������� �˻��ϴ� �Լ�
    public bool CanGo(Vector3 _monAgentDes, out Vector3 posMon)
    {
        NavMeshHit obstaclesHit;
        bool noObstacles = NavMesh.Raycast(transform.position, _monAgentDes, out obstaclesHit, NavMesh.AllAreas);
        if (NavMesh.Raycast(transform.position, _monAgentDes, out obstaclesHit, NavMesh.AllAreas))
        {
            posMon = obstaclesHit.position;
            return noObstacles;
        }
        posMon = _monAgentDes;
        return noObstacles;
    }

}
