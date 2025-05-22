using UnityEngine;

public class Anim_Regdoll : MonoBehaviour
{
    //�������� ������ �ʿ��� �̸� ���� �״ٰ� �� �� �ְ� �ƴϸ� �������� ���� �� ���� // ����� �״� ������
    //������ �� �������� ��������� �ݶ��̴��� �ᵵ ������ �Ⱦ��ٰ� ���ٸ� �ݶ��̴� ����
    // ������ٵ� ���� �������� �߷���������
    // is Kinematic �ⱸ�� - �ִϸ��̼Ǥ��� ���ؼ� Ű�׸�ƽ�� �ƴϾ�, ���࿡ �ٸ��͵鿡 ������ �޾ƾ��Ѵٸ� �ⱸ���� üũ�� �ؾ���

    private Rigidbody[] rbs = null;
    private Collider[] cols = null;

    private bool isActivateRagdoll = false;

    private Animator anim = null;
    private Rigidbody mainRb = null;
    private Collider mainCol = null;

    private void Awake()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        cols = GetComponentsInChildren<Collider>();

        anim = GetComponent<Animator>();

        mainRb = rbs[0]; //ù��°���� �θ�
        mainCol = cols[0];
    }

    private void Start()
    {
        DeactivateRagdoll();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ActivateRagdoll();
        else if (Input.GetKeyDown(KeyCode.W))
            DeactivateRagdoll();
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.CompareTag("Projectile"))
        {
            ActivateRagdoll();
        }
    }

    public  void ActivateRagdoll()
    {
        foreach (Rigidbody rb in rbs)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }

        foreach (Collider col in cols)
        {
            col.enabled = true;
        }
        anim.enabled = false;
        mainRb.useGravity = false;
        mainRb.isKinematic = true;
        mainCol.enabled = false;
    }


    public void DeactivateRagdoll()
    {
        isActivateRagdoll = false;
        foreach (Rigidbody rb in rbs)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        foreach(Collider col in cols)
        {
            col.enabled = false;
        }
        anim.enabled = true;
        mainRb.useGravity = true;
        mainRb.isKinematic = false;
        mainCol.enabled = true;
    }

    

}
