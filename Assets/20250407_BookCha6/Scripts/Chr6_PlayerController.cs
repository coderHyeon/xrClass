using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Chr6_PlayerController : MonoBehaviour
{
    //[SerializeField] Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    private Rigidbody playerRigidbody;
    [SerializeField] float speed = 8f; //이동속력
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 plyerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow) == true) {
        //    // 위쪽 방향키 입력이 감지된 경우 z 방향 힘주기
        //    playerRigidbody.AddForce(0f, 0f, speed);
        //}

        //if(Input.GetKey(KeyCode.DownArrow) == true)
        //{// 아래쪽 방향키 입력이 감지된 경우 - z 방향 힘주기
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}

        //if(Input.GetKey(KeyCode.RightArrow) == true)
        //{// 오른쪽 방향키 입력이 감지된 경우 x 방향 힘주기   
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}

        //if(Input.GetKey(KeyCode.LeftArrow) == true)
        //{// 왼쪽 방향키 입력이 감지된 경우 -x 방향 힘주기
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}
        //수평축과 수직축의 입력값을 갑지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동속도를 입력값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.linearVelocity = newVelocity;

    }

   public void Die()
    {
        gameObject.SetActive(false);
    }
}
