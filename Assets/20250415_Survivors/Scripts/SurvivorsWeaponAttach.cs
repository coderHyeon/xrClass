using UnityEngine;

public class SurvivorsWeaponAttach : MonoBehaviour
{
    private SurvivorsWeaponBase weapon = null;

    public float ShootInterval
    {
        get { if (weapon == null) return 0f; else return weapon.ShootInterval; }
    }
    //무기를 얻는건 플레이어
    //무기 위치, 얻은무기정보, 현재 있는 무기 제거등,, 수행
    public void SetWeapon(SurvivorsWeaponBase _weapon)
    {
        if(weapon !=null)
        {
            Destroy(weapon.gameObject);
        }
        weapon = _weapon;
        weapon.transform.SetParent(transform);//부모로컬포지션 
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localScale = Vector3.one;
        //무기 콜라이더 끄기?는 베이스에
        weapon.DisableCollider();
    }
    public void Shoot(Transform _targetTr)
    {
        if (weapon != null)
            weapon.Shoot(_targetTr);

    }
}
