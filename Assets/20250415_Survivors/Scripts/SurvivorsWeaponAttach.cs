using UnityEngine;

public class SurvivorsWeaponAttach : MonoBehaviour
{
    private SurvivorsWeaponBase weapon = null;

    public float ShootInterval
    {
        get { if (weapon == null) return 0f; else return weapon.ShootInterval; }
    }
    //���⸦ ��°� �÷��̾�
    //���� ��ġ, ������������, ���� �ִ� ���� ���ŵ�,, ����
    public void SetWeapon(SurvivorsWeaponBase _weapon)
    {
        if(weapon !=null)
        {
            Destroy(weapon.gameObject);
        }
        weapon = _weapon;
        weapon.transform.SetParent(transform);//�θ���������� 
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localScale = Vector3.one;
        //���� �ݶ��̴� ����?�� ���̽���
        weapon.DisableCollider();
    }
    public void Shoot(Transform _targetTr)
    {
        if (weapon != null)
            weapon.Shoot(_targetTr);

    }
}
