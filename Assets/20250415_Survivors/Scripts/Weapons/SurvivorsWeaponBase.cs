
using UnityEngine;

public class SurvivorsWeaponBase : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = null;

    protected float shootInterval = 1f;
    private Transform targetTr = null;

    public float ShootInterval { get { return shootInterval; } }

    //public void Shoot(Vector3 _dir)
    //{
    //    GameObject projecileGo = Instantiate(projectilePrefab);
    //    projecileGo.transform.position = transform.position;
    //    SurvivorsWeaponBaseProjectile projectile =
    //        projecileGo.GetComponent<SurvivorsWeaponBaseProjectile>();
    //    projectile.Init(_dir);
    //}
    public virtual void Shoot(Transform _targetTr)
    {
        targetTr = _targetTr;

    }
    //자식용 
    protected Vector3 GetDirectionToTarget()
    {

        return (targetTr.transform.position - transform.position).normalized;
    }
    // [SerializeField] private GameObject projectilePrefab = null; // 이걸 protected 안하고 하는 방법
    protected T InstantiateProjectile<T>()
    {
        GameObject pojectileGo = Instantiate(projectilePrefab);
        return pojectileGo.GetComponent<T>();
        //return Instantiate(projectilePrefab);
        //발사체가 달라지게 다양하니깐 템플릿으로 만든다면 어떤 발사체가 와도 좋음
    }
    public void DisableCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
}


