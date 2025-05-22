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
    // �յڷ� ���°� �����غ��� 

    private void ControllerWASD()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position =
            //    transform.position +
            //    (Vector3.left * moveSpeed * Time.deltaTime);
            //transform�� ���� ���� ���� ��ǥ��, -transform.right �̰� ������ 
            //������� - ���� ��ǥ��
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
        //Axis �� �Ƴ��α� ���� �������°Ͱ� ��� 
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
        // ȸ���� ����������
        // x, y, z ȸ������ �ִ� ���Ͱ� �ƴ϶� ���ʹϾ��̶�� �ڷ����� 
        // ��ü�� ȸ���� ��Ű�µ� �� ���� ���������� �Ѵٸ� ������ �ٲٸ� �� - ���Ϸ���
        // x�� ���ϰ� y�� ���ϰ�, z�� ���ϸ� ���� ����� ���� -> �̷��� �帧�� �ʿ���
        // ���� ������ ȸ�� �̶�� �ؼ� xyz�� �����Ӱ� ����  :  ���� �������� ���� �� (������ 90���� �Ǿ��� ��) ������
        // �̰� �ذ��ҷ��� ���°� ���ʹϾ� - ���Ҽ� ����� ? 
        // ��� �������� ȸ���ϴ��Ŀ� ���� �ٸ�
        // Pitch, Yaw, Roll ȸ����� - ����⿡�� ó�� ���� ���������� ��������� 2������ ǥ������ ��ǥ�� ��,, �׷��� ������ ���� �� �����ϱ� ����� �������� 
        // ��� ���� �ø��°� pitch - x, ����Ⱑ ��۹�� ���ư��� yaw - y, roll z 
        if(Input.GetKey(KeyCode.Q))
        {
            Vector3 euler = transform.rotation.eulerAngles;
            //euler.y += rotSpeed * Time.deltaTime;
            euler.y -= rotSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(euler);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            // up����
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
    }
}
