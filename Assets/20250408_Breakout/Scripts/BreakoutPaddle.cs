using UnityEngine;

public class BreakoutPaddle : MonoBehaviour
{
    //제한이 똑똑하지 않음 벽 길이가 바뀌는건 반영안함
    private const float leftLimit = -13f;
    private const float rightLimit = 13f;
    private float moveSpeed = 20f;
    private Vector3 moveDir = Vector3.zero;

    public Vector3 MoveDirection { get { return moveDir; } }

    
    //리지드바디안씀
    //private void Update()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    Moving(Vector3.right * h);
    //}

    public void MovingHorizontal(float _axisH)

    {
        moveDir = Vector3.right * _axisH * moveSpeed;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        if (transform.position.x < leftLimit)
        {
            //포지션의 값은 직접 못바꾸고 벡터형식으로 해야함
            //transform.poistion.x = leftLimit;
            Vector3 newPos = transform.position;
            newPos.x = leftLimit;
            transform.position = newPos;

        }
        else if(transform.position.x > rightLimit)
        {
            Vector3 newPos = transform.position;
            newPos.x = rightLimit;
            transform.position = newPos;
        }
    }
}
