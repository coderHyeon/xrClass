//using System.Collections;
//using UnityEngine;

//public abstract class SurvivorsWeaponProjectileBase : MonoBehaviour
//{
//    protected Transform targetTr = null;
//    protected Vector3 moveDir = Vector3.zero;

//    protected float moveSpeed = 10f;
//    protected float duration = 3f;

//    //방향
//    public void Init(Vector3 _spwnPos, Transform _targetTr)
//    {
//        transform.position = _spwnPos;
//        targetTr = _targetTr;
//        Vector3 dir = (targetTr.position - _spwnPos).normalized;
//        Init(_spwnPos, dir);
//    }

//    //방향은 없음
//    //위치를 받을 수 도 있고 방향을 받을 수 있는 오버로드 로 바꿀것임
//    public void Init( Vector3 _spwnPos, Vector3 _moveDir)
//    {

//        moveDir = _moveDir;
//        //targetTr = _targetTr;
//        //moveDir = (_targetTr.position - transform.position).normalized;

//        //동기- 절차대로 비동기- 동시에 시작하는것 처럼 보임 코루틴이 비동기처럼
//        StartCoroutine(MovingCoroutine());
//        Destroy(gameObject, duration);
//    }

//    //private IEnumerator MovingCoroutine()
//    //{
//    //    while (true)
//    //    {
//    //        transform.position =
//    //            transform.position +
//    //            (moveDir * moveSpeed * Time.deltaTime);
//    //        yield return null;
//    //    }
//    //}//추상화
//    protected abstract IEnumerator MovingCoroutine();
//}

/////////////////////////////////////////

using System.Collections;
using UnityEngine;

public abstract class SurvivorsWeaponProjectileBase : MonoBehaviour
{
    protected Transform targetTr = null;
    protected Vector3 moveDir = Vector3.zero;

    protected float moveSpeed = 10f;
    protected float duration = 3f;


    public void Init(Vector3 _spawnPos, Transform _targetTr)
    {
        targetTr = _targetTr;
        Vector3 dir =
            (targetTr.position - transform.position).normalized;
        Init(_spawnPos, dir);
    }

    public void Init(Vector3 _spawnPos, Vector3 _moveDir)
    {
        transform.position = _spawnPos;

        moveDir = _moveDir;

        // Sync, Async
        StartCoroutine(MovingCoroutine());

        Destroy(gameObject, duration);
    }

    protected abstract IEnumerator MovingCoroutine();
}