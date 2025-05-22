using UnityEngine;

public class SurvivorsWeaponGun : SurvivorsWeaponBase
{
    private void Start()
    {
        shootInterval = 0.5f;

    }
    // 버츄얼로 만든 이유는 타겟의 변수를 저장하는것은 모두가 해야하는거라 부모가 한거임
    // 추가적으로 어떻게 발사를 할 지 
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
