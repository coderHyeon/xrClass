using UnityEngine;

public class SurvivorsWeaponBomb : SurvivorsWeaponBase
{
    private void Start()
    {
        shootInterval = 4f;

    }
    public override void Shoot(Transform _targetTr)
    {
        base.Shoot(_targetTr);
        SurvivorsWeaponBombProjectile projectile = InstantiateProjectile<SurvivorsWeaponBombProjectile>();
        projectile.Init(transform.position, _targetTr);
    }
}
