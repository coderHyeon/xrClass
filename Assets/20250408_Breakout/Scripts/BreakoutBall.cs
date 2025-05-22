using UnityEngine;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

//리지드바디 강제 
[RequireComponent(typeof(Rigidbody))]
public class BreakoutBall : MonoBehaviour
{
    public delegate void GameOverDelegate();
    public delegate void CollisionBlockDelegate();
    public delegate void CollisionTagName();
    //보통 
    public delegate void VoidVoidDelgate();
    public delegate void VoidIntDelegate(int _value);
    private Rigidbody rb = null;


    private float moveSpeed = 15f;

    private GameOverDelegate gameOverCallback = null;
    private CollisionBlockDelegate collisonBlockCallback = null;
    //private CollisionTagName collisionTagName = null;

    //private BreakoutBall ball = null;
    //private BreakeoutBlockManager block = null;

    public GameOverDelegate GameOverCallback
    {
        set { gameOverCallback = value; }
    }

    public void AddCollisionBlockCallback(CollisionBlockDelegate _callback)
    {
        collisonBlockCallback += _callback;
    }


    private void Awake()
    {
        // 실행시 코드안에서 제어하는방법
        // 리지드바디는 물리엔진을 해주기때문에 업데이트 시킬필요가 없음
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;


    }
    public void ComePareTagNameX(string _tagName, Collider _collider)
    {
        if (_collider.CompareTag(_tagName))
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.x *= -1f;
            rb.linearVelocity = velocity;
            Debug.Log("컴페어태그네임"+"-" + "velocity" + velocity);
        }
    }

    private void OnTriggerEnter(Collider _collider)
    {


        ComePareTagNameY("Paddle", _collider);
        ComePareTagNameY("WallTop", _collider);
        ComePareTagNameY("WallBottom", _collider);
        ComePareTagNameY("Paddle", _collider);



        if (_collider.CompareTag("WallLeft") || _collider.CompareTag("WallRight"))
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.x *= -1f;
            rb.linearVelocity = velocity;
        }


        if (_collider.CompareTag("ColliderLeft") || _collider.CompareTag("ColliderRight"))
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.x *= -1f;
            rb.linearVelocity = velocity;
            // Destroy(_collider.transform.parent.gameObject);
            BreakoutBlock block = _collider.GetComponentInParent<BreakoutBlock>();
            if(block)block.SetActive(false);
            collisonBlockCallback?.Invoke();
        }
        else if (_collider.CompareTag("ColliderTop") || _collider.CompareTag("ColliderBottom"))
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.x = -1f;
            rb.linearVelocity = velocity;
            BreakoutBlock block = _collider.GetComponent<BreakoutBlock>();
            if(block)block.SetActive(false);
            collisonBlockCallback?.Invoke();
        }

        //if (_collider.CompareTag("Block"))
        //{   //부딪혔다는것만 알 수 있음

        //    Vector3 velocity = rb.linearVelocity;
        //    Debug.Log("부딪히는거 확인"+ gameObject.name + this.name + _collider.transform.parent.gameObject);
        //    velocity.y *= -1;
        //    rb.linearVelocity = velocity;
        //    Destroy(_collider.gameObject);
        //}
        
    }
    
    public void ResetMoveDirection()
    {
        //SetMoveDirection(Vector3.zero);
        rb.linearVelocity = Vector3.zero;
    }

    public void SetMoveDirection(Vector3 _moveDir)
    { // 방향벡터 //정규화를 통해서 방향벡터로 만들어줘야함 // 벡터에다가 길이만큼,,,,
        //방향벡터 만드는방법 2가지
        //노멀라이즈
        _moveDir.Normalize();
        Vector3 norDir = _moveDir.normalized;
        rb.linearVelocity = _moveDir * moveSpeed;

    }

    
    public void ComePareTagNameY(string _tagName, Collider _collider)
    {
        if (_collider.CompareTag(_tagName))
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.y *= -1f;
            rb.linearVelocity = velocity;
            Debug.Log("컴페어태그네임");
        }
    }
}
