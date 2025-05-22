
using System.Collections.Generic;
using UnityEngine;

public class SurvivorsMonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab = null;
    [SerializeField] private Transform targetTr = null;

    private float spawnDist = 30f;
    private float spawnInterval = 0.3f;
    private float elasedTime = 0f;// 누적시간

    private List<SurvivorsMonster> monsterList = new List<SurvivorsMonster>();
    //SurvivorsMonster.Init(targetTr);

    private void Update()
    {
        elasedTime += Time.deltaTime;
        if(elasedTime >= spawnInterval)
        {
            SpawnMonster();
            elasedTime = 0f;
        }
        CheckDead();
    }

    private void SpawnMonster()
    {
        GameObject monsterGo =
            Instantiate(monsterPrefab);
        float theta = Random.Range(0f, 360f);
        Vector3 pos = new Vector3(
            Mathf.Cos(theta),
            Mathf.Sin(theta),
            0f) * spawnDist;
        monsterGo.transform.position = pos;

        SurvivorsMonster monster = monsterGo.GetComponent<SurvivorsMonster>();
        monster.Init(targetTr);

        monsterList.Add(monster);
    }
    public SurvivorsMonster GetNearMonster(Vector3 _pos)
    {// 제일 작은걸 찾을려고 하면되는데 강사님이 해보면 좋다고 함
        //최소값 구하기
        if (monsterList.Count == 0) return null;
        SurvivorsMonster nearMob = monsterList[0];
        for (int i = 1; i < monsterList.Count; ++i)
        {

            float nearDist =
                Vector3.Distance(_pos, nearMob.transform.position);
            float curDist =
                (_pos - monsterList[i].transform.position).sqrMagnitude; // 헉 ... 목적지구하는거 다른 방법이다!!!?방향 벡터 //route 빼고 계산해주는게 sqrMagnitude 정화한 거리에는 쓰면 안됨
            if(curDist < nearDist)
            {
                nearMob = monsterList[i];
            }
        }
        return nearMob;

    }
    private void CheckDead()
    {
        foreach(SurvivorsMonster monster in monsterList)
        {
            if(monster.IsDead)
            {
                monsterList.Remove(monster);
                Destroy(monster.gameObject);
                return;
            }
        }
    }

}
