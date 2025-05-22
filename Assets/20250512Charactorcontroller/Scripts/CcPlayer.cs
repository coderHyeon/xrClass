using UnityEngine;

public class CcPlayer : MonoBehaviour
{
    private Transform camTr = null;

    private float curRotX = 0f;
    private float mouseSensitivity = 2f;

    private float moveSpeed = 10f;
    private CharacterController charController = null;
    private Vector3 moveDest = Vector3.zero;

    private void Awake()
    {
        camTr = GetComponentInChildren<Camera>().transform;
        charController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        curRotX = transform.localEulerAngles.x;

    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        PlayerRotate(mouseX);
        CameraRotate(mouseY);

        float axisH = Input.GetAxis("Horizontal");//Horizontal
        float axisV = Input.GetAxis("Vertical");//Vertical

        PlayerMoving(axisH, axisV);
    }

    private void PlayerRotate(float _mouseX)
    {
        curRotX += _mouseX * mouseSensitivity;
        transform.rotation = Quaternion.Euler(0f, curRotX, 0f); // ������ ������ �����ϰ� �������°�
    }


    // LootAt Camera                                                                                                                                                      
    private void CameraRotate(float _mouseY)
    {
        // camTr.Rotate(Vector3.up, //����������� ������
        // _mouseX * mouseSensitivity * Time.deltaTime);

        transform.Translate(Vector3.forward); // �� �ڽ��� �����̴µ� ���� ��ǥ�� �ؾ�����?  Translate ����� ����� �Լ��� �ϴ� ȸ���� �� ���ð� �ƴ϶� ȸ���� �� ������ ���� �ʿ䰡 ���°�
        transform.Translate(transform.forward);

        Vector3 curRot = camTr.transform.rotation.eulerAngles;
        //curRot = transform.rotation.eulerAngles;
        float rotX = curRot.x;
        rotX =  curRot.x -= _mouseY * mouseSensitivity;
        rotX = Mathf.Lerp(0f, 60f, Time.deltaTime);

        //Debug.Log("curRot.x :" + curRot.x);
        //curRot.x = Mathf.Clamp(curRot.x, -30f, 60f); 


        camTr.localRotation =
            Quaternion.AngleAxis(curRot.x, Vector3.right);

            //Quaternion.Lerp(���۾ޱ�, ���ޱ�, t);
    }
    
    private void PlayerMoving(float _axisH, float _axisV)
    {

        // ������ǥ�� ������ǥ�� �ٲٴ� ��
   

        Vector3 dir = (transform.forward * _axisV) + (transform.right * _axisH);
        //����
        charController.SimpleMove(
           transform.forward * _axisV * moveSpeed);
        //������
        dir.Normalize();
        charController.SimpleMove(
                      dir * moveSpeed);
    }

    private void Looking()
    {
        float angle = Mathf.Atan2(moveDest.z, moveDest.x) * Mathf.Rad2Deg;
        angle *= Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, -angle + 90f, 0f);
    }
}
