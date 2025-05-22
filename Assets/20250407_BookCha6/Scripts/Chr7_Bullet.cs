using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chr7_Bullet : MonoBehaviour
{
    [SerializeField,Range(1f, 100f)] float speed = 8f;
    private Rigidbody BulletRigidbody;
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        BulletRigidbody = GetComponent<Rigidbody>();
        //리지바디의 속도 = 앞쪽 방향 * 이동속력
        BulletRigidbody.linearVelocity = transform.forward * speed;

        //3초뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f); 
    }

    //트리거 충돌시 자동으로 실해되는 메서드
    void OnTriggerEnter(Collider _other)
    {
    //충돌한 상대방 게임 오브젝트가 Player 태그를 가진경우
        if(_other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 PlyerController 컴포넌트 가져오기
            Chr6_PlayerController playerController = _other.GetComponent<Chr6_PlayerController>();

            // 상대방으로부터 PlyerController 컴포넌트를 가져오는 데 성공했다면
            if(playerController != null)
            {
                //상대방으로부터 PlyerController 컴포넌트의 Die() 메서드가 실행
                playerController.Die();

            }


        }

    }
}
