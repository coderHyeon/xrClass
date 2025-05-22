
using UnityEngine;

public class VMPlayer : MonoBehaviour
{
    //���� ����ٰ� ���� ����
    public enum Estate { Stop, Move}
    public struct SInfo 
    {//�������ͽ�, ���� �̷��� �̹��ϰ� �ٸ�
        public int money;
        public int hp;
        public int atk;
        public int def;
        public int agi;
        public int dex;
        //����ü �����ڸ� ���鶧 �Ѱ��� ������ �ȵ�
        public SInfo(int _money,int _hp, int _atk, int _def, int _agi, int _dex)
        {
            money = _money;
            hp = _hp;
            atk = _atk;
            def = _def;
            agi = _agi;
            dex = _dex;
        }
    }
    
    [SerializeField] private VMPlayerInfoCanvas playerInfoCanvas = null;
    // �����۸����� �÷��� ȿ���� �־�����ϱ⶧���� ���� ���������
    private SInfo info;

    private Estate state = Estate.Stop;
    //private SStatus status = new SStatus();����ü �ȿ� ������
    //private SInfo? status = null; //������ ����ü�� null�� �ε����� nullable�� ����
  
    private float moveSpeed = 15f;
    // Destination(dest, dst)  ������
    private Vector3 moveDest = Vector3.zero;
    // Distance dist
    private float stopDist = 0.05f;
    //�÷��̾�� ��� ����ӽ��� ������� �߻�ȭ�� �ϴ��� �ؾ��� 
    private VMVendingMachine vm = null;
    public SInfo? Status { get { return info; } }
    private void Awake()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();//AddComponent �ܵ����Ұ� GetComponent �������� �̹� ������Ʈ�� ������ null
        //if(rb == null)
        rb = GetComponent<Rigidbody>(); // �ִ�������Ʈ ���� ������ nullGetComponent
        rb.useGravity = false;
        rb.constraints = 
            RigidbodyConstraints.FreezePositionY | 
            RigidbodyConstraints.FreezeRotationX | 
            RigidbodyConstraints.FreezeRotationY | 
            RigidbodyConstraints.FreezePositionZ;
    }

    private void Start()
    {

        info = new SInfo(1000,10, 3, 4, 1, 2);
        UpdatePlayerInfoCanvas();
    }

     private void Update()
    {
        //if (VMGameState.curState == VMGameState.EGameState.OpenUI)
        //    return;
        //if (VMGameState.IsOpenUI ) return ; // �Լ��� �����α�
        if (VMGameState.IsOpenUI()) return;

        MovingWithAxis();
        MovingWithMouse();
        MoingProcess();
        if (vm != null && Input.GetKeyDown(KeyCode.E))
            vm.Interaction(info.money, OnClickButton);
    }
    private void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.CompareTag("VendingMachine"))
        {
            StopMoving();
        }
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("VendingMachine"))
            vm = _collider.GetComponent<VMVendingMachine>();
        else if (_collider.CompareTag("Potion"))
        {
            Debug.Log("Drinkinge: " + _collider.name);
            VMPotion potion = _collider.GetComponent<VMPotion>();
            potion.Drink(this);
            UpdatePlayerInfoCanvas();

            Destroy(potion.gameObject);
        }
    }

    private void OnTriggerExit(Collider _collider)
    {
        if (_collider.CompareTag("VendingMachine"))
            vm = null;
    }

    private void MovingWithMouse()
    { 
        if(Input.GetMouseButtonDown(0))
        {
            ////����Ƽ�� ���������ο� ����� ���ߴ��� ī�޶� ������ ���� = ���� ī�޶� �������� �� �� �ֱ� ����
            //Vector3 mousePos = Input.mousePosition; //���콺 �ȼ���ǥ�Դ� ������ �Ǿ����� 
            //Camera cam = Camera.main;
            //mousePos.z = cam.nearClipPlane;
            //Vector3 screenToWorld =
            //    cam.ScreenToWorldPoint(mousePos);
            //Vector2 dir = cam.transform.forward; //!!!!!!!!!!!!!!!!!!!!!!���� ���⸸ ��� ��!!!!!!!!!!!!!!!!!!!!!!
            //// ��Ʈ��Ʈ ��Ÿ��, �ܺ��ǰ� ���� ���縦 �ҷ���
            //// ref, out�� �ʿ����Լ����� �Լ��ܺ��� ���� �ٲ� �� ���� ref�� ���� �ٲ㵵 �ǰ� �ȹٲ㵵 �� out�� ���� �ȹٲٸ� �ȵ�
            //RaycastHit hitInfo;
            //if (Physics.Raycast(screenToWorld, dir, out hitInfo))
            //{
            //    //�ɷȴ��� bool���� �����µ� 
            //    //�ʿ��Ѱ� ��ǥ�� RaycastHit hit ����ϸ��
            //    Debug.Log(hitInfo.transform.name);
            //}
            //Debug.DrawRay(screenToWorld, dir * 1000f, Color.blue);// ����׿� Ȯ���ϱ�

            //!!!!!!!!!!!!!!!!!!!!!!���� ���⸸ ��� ��!!!!!!!!!!!!!!!!!!!!!!
            Vector3 mousePos = Input.mousePosition;

            Camera cam = Camera.main;
            mousePos.z = cam.nearClipPlane;
            //Debug.Log("cam.nearClipPlane" + cam.nearClipPlane);
            Vector3 screenToWorld =
                cam.ScreenToWorldPoint(mousePos);
            Vector3 dir = screenToWorld - cam.transform.position;

            RaycastHit hitInfor;
            if (Physics.Raycast(screenToWorld, dir, out hitInfor))
            {
                if (hitInfor.transform.CompareTag("Player")) return;
                moveDest = hitInfor.point;
                LookAtdestination();
                state = Estate.Move;
            }




            //������ �������� ���� ���⸸ ��Ե�

            //Vector3 mousePos = Input.mousePosition;
            //Ray ray = Camera.main.ScreenPointToRay(mousePos);
            //RaycastHit hitInfor;
            //if (Physics.Raycast(ray, out hitInfor))
            //{
            //    if (hitInfor.transform.CompareTag("Player")) return;
            //    // Debug.Log(hitInfor.transform.name);
            //    Debug.Log(Input.mousePosition);
            //    //Debug.Log(hitInfor.point);//�� ��ġ���� �÷��̾ �ɾ���

            //    //moveDest = hitInfor.point - transform.position;
            //    moveDest = hitInfor.point;
            //    //moveDir.Normalize(); 
            //    LookAtdestination();
            //    state = Estate.Move;
            //}
        }
    }

    private void MoingProcess()
    {
        if (state == Estate.Stop) return;
        //������
        Vector3 moveDir = moveDest - transform.position;
        moveDir.y = 0f;
         transform.position =
            transform.position +
            (moveDir * moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveDest) < stopDist/*0f*/ ) // ���� �����߿� ����
        { //�ε��Ҽ��� �������ο� 0f�� ������ ����
            // stop dist �� ���� ����
            //ĳ���͸� �ٶ󺸰� �ҷ��� �����̼ǰ��� �ʿ��� -> 
         
            StopMoving();
        }
    }

    private void StopMoving()
    {
        moveDest = Vector3.zero;
        state = Estate.Stop;
    }

    private void LookAtdestination()
    {
        Vector3 dir = moveDest - transform.position; // �������
        float yawAngle = Mathf.Atan2(dir.z, dir.x);
        yawAngle *= Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, -yawAngle+90f, 0f);
    }

    private void MovingWithAxis()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0f, v);
        transform.Translate(dir * moveSpeed * Time.deltaTime);

    }

    private void UpdatePlayerInfoCanvas()
    {
        playerInfoCanvas.SetInfo(info);
    }

    //private void OnClickButton(int _price)
    //{
    //    if (info.money < _price) return;

    //    info.money -= _price;
    //    UpdatePlayerInfoCanvas();
    //}
     private void OnClickButton(int _price)
    {
        if (info.money < _price) return;

        info.money -= _price;
        UpdatePlayerInfoCanvas();
        vm.Interaction(info.money, OnClickButton);
    }

    public void AddHealthPoint(int _hp)
    {
        info.hp += _hp;
    }
    public void AddAttackPoint(int _atk)
    {
        info.atk += _atk;
    }
    public void AddDefencePoint(int _def)
    {
        info.def += _def;
    }
    public void AddAgilityPoint(int _agi)
    {
        info.agi += _agi;
    }
    public void AdddexterityPoint(int _dex)
    {
        info.dex = +_dex;
    }
       
}
