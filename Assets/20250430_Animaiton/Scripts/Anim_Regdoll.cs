using UnityEngine;

public class Anim_Regdoll : MonoBehaviour
{
    //죽을때만 렉돌이 필요함 미리 만들어서 켰다가 끌 수 있고 아니면 죽을때만 만들 수 있음 // 현재는 켰다 껐다임
    //부위별 총 맞을때는 현재상태의 콜라이더를 써도 되지만 안쓴다고 본다면 콜라이더 끄기
    // 리지드바디를 쓰지 않을때는 중력을꺼야함
    // is Kinematic 기구학 - 애니메이션ㅇ르 통해서 키네메틱이 아니야, 만약에 다른것들에 영향을 받아야한다면 기구학을 체크를 해야함

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

        mainRb = rbs[0]; //첫번째꺼는 부모꺼
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
