using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chr7_Bullet : MonoBehaviour
{
    [SerializeField,Range(1f, 100f)] float speed = 8f;
    private Rigidbody BulletRigidbody;
    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        BulletRigidbody = GetComponent<Rigidbody>();
        //�����ٵ��� �ӵ� = ���� ���� * �̵��ӷ�
        BulletRigidbody.linearVelocity = transform.forward * speed;

        //3�ʵڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f); 
    }

    //Ʈ���� �浹�� �ڵ����� ���صǴ� �޼���
    void OnTriggerEnter(Collider _other)
    {
    //�浹�� ���� ���� ������Ʈ�� Player �±׸� �������
        if(_other.tag == "Player")
        {
            //���� ���� ������Ʈ���� PlyerController ������Ʈ ��������
            Chr6_PlayerController playerController = _other.GetComponent<Chr6_PlayerController>();

            // �������κ��� PlyerController ������Ʈ�� �������� �� �����ߴٸ�
            if(playerController != null)
            {
                //�������κ��� PlyerController ������Ʈ�� Die() �޼��尡 ����
                playerController.Die();

            }


        }

    }
}
