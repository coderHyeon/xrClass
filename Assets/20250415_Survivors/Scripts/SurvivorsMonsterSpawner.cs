
using System.Collections.Generic;
using UnityEngine;

public class SurvivorsMonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab = null;
    [SerializeField] private Transform targetTr = null;

    private float spawnDist = 30f;
    private float spawnInterval = 0.3f;
    private float elasedTime = 0f;// �����ð�

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
    {// ���� ������ ã������ �ϸ�Ǵµ� ������� �غ��� ���ٰ� ��
        //�ּҰ� ���ϱ�
        if (monsterList.Count == 0) return null;
        SurvivorsMonster nearMob = monsterList[0];
        for (int i = 1; i < monsterList.Count; ++i)
        {

            float nearDist =
                Vector3.Distance(_pos, nearMob.transform.position);
            float curDist =
                (_pos - monsterList[i].transform.position).sqrMagnitude; // �� ... ���������ϴ°� �ٸ� ����̴�!!!?���� ���� //route ���� ������ִ°� sqrMagnitude ��ȭ�� �Ÿ����� ���� �ȵ�
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
