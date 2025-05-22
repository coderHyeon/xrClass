using UnityEngine;


public class AniPrac : MonoBehaviour
{
    private Animator anim = null;
    private Animation idle = null;
    private Vector3 moveDest = Vector3.zero;
    private float moveSpeed = 5f;
    float hAxis;
    float vAxis;
    bool wolkW;
    bool runshift;
    bool runQ;
    bool runE;
    bool jumpSpace;
    bool workS;
    bool wolkA;
    bool wolkD;

    Vector3 moveVec;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //idle = GetComponent<Animation>();

    }

    private void Start()
    {
        
    }

    //GetKeyDown 키 누름 상태값 변경
    //GetKey 키 누르는 중
    //GetKeyUp 키 손뗌
    private void Update()
    {
        MovingWithAxis();
        MovingProcess();
        //LookAtDestination();


        runshift = Input.GetKey(KeyCode.LeftShift);
        runQ = Input.GetKey(KeyCode.Q);
        runE = Input.GetKey(KeyCode.E);
        wolkW = Input.GetKey(KeyCode.W);
        workS = Input.GetKey(KeyCode.S);
        wolkA = Input.GetKey(KeyCode.A);
        wolkD = Input.GetKey(KeyCode.D);

        jumpSpace = Input.GetKey(KeyCode.Space);



        anim.SetBool("JumpState", jumpSpace);
        
        anim.SetBool("RunState", runshift);
        anim.SetBool("LeftRunState", runQ);
        anim.SetBool("RightRunState", runE);
       
        
        //transform.LookAt(transform.position + moveVec);
    }
    private void MovingWithAxis()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0f, v);
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    private void MovingProcess()
    {

        Vector3 moveDir = moveDest - transform.position;
        moveDir.y = 0f;
        moveDir.Normalize();
        transform.position =
            transform.position +
            (moveDir * moveSpeed * Time.deltaTime);

        anim.SetBool("WolkState", moveDir.z != Vector3.zero.z && wolkW);
        anim.SetBool("WolkBackState", moveDir.z != Vector3.zero.z && workS);
        anim.SetBool("WolkL", wolkA);
        anim.SetBool("WolkR", wolkD);
    }

    private void LookAtDestination()
    {
        Vector3 dir = moveDest - transform.position;
        float yawAngle = Mathf.Atan2(dir.z, dir.x);
        yawAngle *= Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, -yawAngle + 90f, 0f);
    }

    //rightRunState RunState JumpState RadightRunState
}
























/////////////////////////////////////////////////////////////
//private bool jumpTrance = false;
//private bool workTrance = false;
//private bool runTrance = false;
//private bool leftRunTrance = false;
//private bool rightRunTrance = false;
//if (Input.GetKey(KeyCode.Space))
//{
//    jumpTrance = true;
//    anim.SetBool("JumpState", jumpTrance);
//}else
//{
//    jumpTrance = false;
//    anim.SetBool("JumpState",jumpTrance);
//}

//if (Input.GetKey(KeyCode.W))
//{
//    workTrance = true;
//    anim.SetBool("WorkState", workTrance);

//    if (Input.GetKey(KeyCode.LeftShift))
//    {
//        runshift = true;
//        anim.SetBool("RunState", runshift);
//        if (Input.GetKey(KeyCode.Q))
//        {
//            leftRunTrance = true;
//            anim.SetBool("LeftRunState", leftRunTrance);
//        }
//        else if (Input.GetKey(KeyCode.E))
//        {
//            rightRunTrance = true;
//            anim.SetBool("RightRunState", rightRunTrance);
//        }
//        else
//        {
//            leftRunTrance = false;
//            anim.SetBool("LeftRunState", leftRunTrance);

//            rightRunTrance = false;
//            anim.SetBool("RightRunState", rightRunTrance);
//        }
//    }
//    else
//    {
//        runTrance = false;
//        anim.SetBool("RunState", runTrance);

//    }
//}
//else
//{
//    workTrance = false;
//    anim.SetBool("WorkState", workTrance);

//}