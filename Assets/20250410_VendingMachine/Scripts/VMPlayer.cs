
using UnityEngine;

public class VMPlayer : MonoBehaviour
{
    //돈은 여기다가 넣을 예쩡
    public enum Estate { Stop, Move}
    public struct SInfo 
    {//스테이터스, 스탯 이런게 미묘하게 다름
        public int money;
        public int hp;
        public int atk;
        public int def;
        public int agi;
        public int dex;
        //구조체 생성자를 만들때 한개라도 빠지면 안됨
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
    // 아이템먹으면 플레어 효과를 넣어줘야하기때문에 갱신 시켜줘야함
    private SInfo info;

    private Estate state = Estate.Stop;
    //private SStatus status = new SStatus();구조체 안에 생성함
    //private SInfo? status = null; //원래는 구조체의 null이 인되지만 nullable로 가능
  
    private float moveSpeed = 15f;
    // Destination(dest, dst)  목적지
    private Vector3 moveDest = Vector3.zero;
    // Distance dist
    private float stopDist = 0.05f;
    //플레이어는 사실 밴딩머신을 몰라야함 추상화를 하던가 해야함 
    private VMVendingMachine vm = null;
    public SInfo? Status { get { return info; } }
    private void Awake()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();//AddComponent 단독사용불가 GetComponent 가능했으 이미 컴포넌트가 있으면 null
        //if(rb == null)
        rb = GetComponent<Rigidbody>(); // 있는컴포넌트 들고옴 없으면 nullGetComponent
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
        //if (VMGameState.IsOpenUI ) return ; // 함수로 만들어두기
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
            ////유니티가 파이프라인에 행렬을 곱했던걸 카메라가 가지고 있음 = 이유 카메라가 여러대일 수 도 있기 때문
            //Vector3 mousePos = Input.mousePosition; //마우스 픽셀좌표게는 정수로 되어있음 
            //Camera cam = Camera.main;
            //mousePos.z = cam.nearClipPlane;
            //Vector3 screenToWorld =
            //    cam.ScreenToWorldPoint(mousePos);
            //Vector2 dir = cam.transform.forward; //!!!!!!!!!!!!!!!!!!!!!!같은 방향만 쏘게 됨!!!!!!!!!!!!!!!!!!!!!!
            //// 스트럭트 값타입, 외부의걸 얕은 복사를 할려면
            //// ref, out이 필요함함수에서 함수외부의 값을 바꿀 수 있음 ref는 값을 바꿔도 되고 안바꿔도 됨 out은 값을 안바꾸면 안됨
            //RaycastHit hitInfo;
            //if (Physics.Raycast(screenToWorld, dir, out hitInfo))
            //{
            //    //걸렸는지 bool값이 나오는데 
            //    //필요한건 좌표임 RaycastHit hit 사용하면됨
            //    Debug.Log(hitInfo.transform.name);
            //}
            //Debug.DrawRay(screenToWorld, dir * 1000f, Color.blue);// 디버그용 확인하기

            //!!!!!!!!!!!!!!!!!!!!!!같은 방향만 쏘게 됨!!!!!!!!!!!!!!!!!!!!!!
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




            //위에는 레이저가 같은 방향만 쏘게됨

            //Vector3 mousePos = Input.mousePosition;
            //Ray ray = Camera.main.ScreenPointToRay(mousePos);
            //RaycastHit hitInfor;
            //if (Physics.Raycast(ray, out hitInfor))
            //{
            //    if (hitInfor.transform.CompareTag("Player")) return;
            //    // Debug.Log(hitInfor.transform.name);
            //    Debug.Log(Input.mousePosition);
            //    //Debug.Log(hitInfor.point);//저 위치까지 플레이어가 걸어가면됨

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
        //방향계산
        Vector3 moveDir = moveDest - transform.position;
        moveDir.y = 0f;
         transform.position =
            transform.position +
            (moveDir * moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveDest) < stopDist/*0f*/ ) // 답이 여기중에 있음
        { //부동소수점 오차로인에 0f가 나오기 힘듦
            // stop dist 를 대충 정함
            //캐릭터를 바라보게 할려면 로테이션값이 필요함 -> 
         
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
        Vector3 dir = moveDest - transform.position; // 방향백터
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
