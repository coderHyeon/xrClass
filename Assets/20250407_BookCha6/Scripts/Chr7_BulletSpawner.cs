using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Chr7_BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;// ������ ź���� ���� ������
    [SerializeField] float spawnRateMin = 0.5f; //�ּ� �����ֱ�
    [SerializeField] float spawnRateMax = 3f; //�ִ���� �ֱ�

    private Transform target; // �߻��� ���
    private float spawnRate; // �����ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�


    void Start()
    {//�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        //ź�� ���� ������ spawnRateMin �� spawnRateMax ���̿��� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindFirstObjectByType<Chr6_PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn�� ����
        timeAfterSpawn += Time.deltaTime;

        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if(timeAfterSpawn >= spawnRate)
        {
            //������ �ð��� ����
            timeAfterSpawn = 0f;

            // bulletPrefab�� �������� transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //������  bullet ���� ������Ʈ�� ���� ������ target���� ���ϵ��� ȸ��
            bulletPrefab.transform.LookAt(target);

            //������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
