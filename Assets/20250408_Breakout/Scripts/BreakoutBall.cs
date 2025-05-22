using UnityEngine;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

//������ٵ� ���� 
[RequireComponent(typeof(Rigidbody))]
public class BreakoutBall : MonoBehaviour
{
    public delegate void GameOverDelegate();
    public delegate void CollisionBlockDelegate();
    public delegate void CollisionTagName();
    //���� 
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
        // ����� �ڵ�ȿ��� �����ϴ¹��
        // ������ٵ�� ���������� ���ֱ⶧���� ������Ʈ ��ų�ʿ䰡 ����
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
            Debug.Log("������±׳���"+"-" + "velocity" + velocity);
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
        //{   //�ε����ٴ°͸� �� �� ����

        //    Vector3 velocity = rb.linearVelocity;
        //    Debug.Log("�ε����°� Ȯ��"+ gameObject.name + this.name + _collider.transform.parent.gameObject);
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
    { // ���⺤�� //����ȭ�� ���ؼ� ���⺤�ͷ� ���������� // ���Ϳ��ٰ� ���̸�ŭ,,,,
        //���⺤�� ����¹�� 2����
        //��ֶ�����
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
            Debug.Log("������±׳���");
        }
    }
}
