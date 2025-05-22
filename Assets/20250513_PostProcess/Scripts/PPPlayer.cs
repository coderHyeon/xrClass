using UnityEngine;

public class PPPlayer : MonoBehaviour
{
    private Transform camTr = null;

    private float rotX = 0f;
    private float rotY = 0f;
    private float mouseSensitivity = 130f;

    private float moveSpeed = 5f;

    private GameObject interactionGo = null;


    private void Awake()
    {
        camTr = GetComponentInChildren<Camera>().transform;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotX = transform.rotation.eulerAngles.x;
        rotY = camTr.rotation.eulerAngles.y;
    }

    private void Update()
    {
        float axisX = Input.GetAxis("Mouse X");
        float axisY = Input.GetAxis("Mouse Y");
        PlayerYaw(axisX);
        CameraPitch(axisY);

        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        PlayerMoving(axisH, axisV);

        if (Input.GetKeyDown(KeyCode.E))
            InteractionProcess();
    }

    private void PlayerYaw(float _axisX)
    {
        float newRotX = rotX + (_axisX * mouseSensitivity);
        rotX = Mathf.Lerp(rotX, newRotX, Time.deltaTime);
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y = rotX;
        transform.rotation = Quaternion.Euler(rot);
    }

    private void CameraPitch(float _axisY)
    {
        float newRotY = rotY - (_axisY * mouseSensitivity);
        rotY = Mathf.Lerp(rotY, newRotY, Time.deltaTime);
        Vector3 rot = camTr.rotation.eulerAngles;
        rot.x = rotY;
        camTr.rotation = Quaternion.Euler(rot);
    }

    private void PlayerMoving(float _axisH, float _axisV)
    {
        Vector3 moveH = camTr.transform.right * _axisH;
        moveH.y = 0f;
        moveH.Normalize();
        Vector3 moveV = camTr.transform.forward * _axisV;
        moveV.y = 0f;
        moveV.Normalize();

        Vector3 moveDir = (moveH + moveV).normalized;

        transform.position =
            transform.position +
            (moveDir * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Interaction"))
        {
            interactionGo = _collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider _collider)
    {
        if (_collider.CompareTag("Interaction"))
        {
            if (interactionGo != null)
                interactionGo = null;
        }
    }

    private void InteractionProcess()
    {
        if (interactionGo == null) return;

        ParticleSystem ps =
            interactionGo.GetComponentInChildren<ParticleSystem>();
        Light light =
            interactionGo.GetComponentInChildren<Light>();
        if (ps != null)
        {
            if (ps.isPlaying)
            {
                ps.Stop(true);
                light.enabled = false;
            }
            else
            {
                ps.Play(true);
                light.enabled = true;
            }
        }
    }
}
