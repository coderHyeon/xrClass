using UnityEngine;

public class SurvivorsWeaponSinGun : SurvivorsWeaponBase
{
    private void Start()
    {
        shootInterval = 0.3f;
    }

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
