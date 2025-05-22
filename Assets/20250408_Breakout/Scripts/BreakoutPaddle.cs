using UnityEngine;

public class BreakoutPaddle : MonoBehaviour
{
    //������ �ȶ����� ���� �� ���̰� �ٲ�°� �ݿ�����
    private const float leftLimit = -13f;
    private const float rightLimit = 13f;
    private float moveSpeed = 20f;
    private Vector3 moveDir = Vector3.zero;

    public Vector3 MoveDirection { get { return moveDir; } }

    
    //������ٵ�Ⱦ�
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
            //�������� ���� ���� ���ٲٰ� ������������ �ؾ���
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
