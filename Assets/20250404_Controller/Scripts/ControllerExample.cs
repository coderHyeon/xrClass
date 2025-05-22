using UnityEngine;

public class ControllerExample : MonoBehaviour
{
    [SerializeField, Range(10f, 50f)] private float moveSpeed = 10f;
    [SerializeField, Range(50f, 100f)] private float rotSpeed = 100f;
    private void Update()
    {
        //ControllerWASD();
        ControllerAxis2();
        ControllerAxis();
        ControllerRotate();
    }
    // 앞뒤로 가는거 직접해보기 

    private void ControllerWASD()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position =
            //    transform.position +
            //    (Vector3.left * moveSpeed * Time.deltaTime);
            //transform은 나의 기준 로컬 좌표계, -transform.right 이게 왼쪽임 
            //세상기준 - 원리 좌표계
            transform.position = transform.position +
                (-transform.right * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position =
                transform.position +
                (Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //
        }
    }

    private void ControllerAxis()
    {
        //Axis 축 아날로그 축을 가져오는것과 비슷 
        float vertical = Input.GetAxis("Vertical");
        if(vertical != 0f)
        {
            transform.position =
            transform.position +
            (Vector3.forward * vertical * moveSpeed * Time.deltaTime);
        }

       

    }
    private void ControllerAxis2()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0f)
        {
            transform.position =
            transform.position +
            (Vector3.right * horizontal * moveSpeed * Time.deltaTime);
        }
    }

    private void ControllerRotate()
    {
        // 회전이 복잡한이유
        // x, y, z 회전값이 있는 벡터가 아니라 쿼터니언이라는 자료형임 
        // 물체를 회전을 시키는데 이 값을 수학적으로 한다면 각도를 바꾸면 됨 - 오일러씨
        // x축 곱하고 y축 곱하고, z축 곱하면 최종 결과가 나옴 -> 이러한 흐름이 필요함
        // 삼축 자유도 회전 이라고 해서 xyz를 자유롭게 돌림  :  축이 같아지는 때가 옴 (한축을 90도가 되었을 때) 짐벌락
        // 이걸 해결할려고 나온게 쿼터니언 - 복소수 만들기 ? 
        // 어디를 기준으로 회전하느냐에 따라 다름
        // Pitch, Yaw, Roll 회전용어 - 비행기에서 처음 나옴 삼차원에서 살고있지만 2차원의 표현으로 좌표과 됨,, 그러나 비행기는 위에 떠 있으니까 비행기 기준으로 
        // 기수 앞을 올리는것 pitch - x, 비행기가 뱅글뱅글 돌아가면 yaw - y, roll z 
        if(Input.GetKey(KeyCode.Q))
        {
            Vector3 euler = transform.rotation.eulerAngles;
            //euler.y += rotSpeed * Time.deltaTime;
            euler.y -= rotSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(euler);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            // up벡터
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
    }
}
