
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
    //�ڽĿ� 
    protected Vector3 GetDirectionToTarget()
    {

        return (targetTr.transform.position - transform.position).normalized;
    }
    // [SerializeField] private GameObject projectilePrefab = null; // �̰� protected ���ϰ� �ϴ� ���
    protected T InstantiateProjectile<T>()
    {
        GameObject pojectileGo = Instantiate(projectilePrefab);
        return pojectileGo.GetComponent<T>();
        //return Instantiate(projectilePrefab);
        //�߻�ü�� �޶����� �پ��ϴϱ� ���ø����� ����ٸ� � �߻�ü�� �͵� ����
    }
    public void DisableCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
}


