using UnityEngine;

public class SurvivorsWeaponGun : SurvivorsWeaponBase
{
    private void Start()
    {
        shootInterval = 0.5f;

    }
    // ������ ���� ������ Ÿ���� ������ �����ϴ°��� ��ΰ� �ؾ��ϴ°Ŷ� �θ� �Ѱ���
    // �߰������� ��� �߻縦 �� �� 
    public override void Shoot(Transform _targetTr)
    {
        base.Shoot(_targetTr);

        SurvivorsWeaponProjectileBase projectile = 
            InstantiateProjectile<SurvivorsWeaponProjectileBase>();
        projectile.Init(
            transform.position,
            _targetTr
            );
    }

}
