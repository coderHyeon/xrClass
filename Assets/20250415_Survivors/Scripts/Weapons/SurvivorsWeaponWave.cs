using UnityEngine;

public class SurvivorsWeaponWave : SurvivorsWeaponBase
{
    private int projectileCnt = 7;
    private void Start()
    {
        shootInterval =2f;
    }
    public override void Shoot(Transform _targetTr)
    {
        base.Shoot(_targetTr);

        float angleOffset = 360f / projectileCnt;
        float angleOffsetRi = (2f * Mathf.PI) / projectileCnt;
        float angle = 0f;
        for (int i = 0; i < projectileCnt; ++i)
        {
            SurvivorsWeaponProjectileBase projectile =
                InstantiateProjectile<SurvivorsWeaponProjectileBase>();
            angle = angleOffsetRi * i;
            //angle = angleOffset * i;
            //angle += Mathf.Deg2Rad;
            Vector3 dir = new Vector3(
                Mathf.Cos(angle),
                Mathf.Sin(angle),
                0f);
            projectile.Init(
                transform.position,
                dir
                );
            //3. 바라보는 방향으로 발사되는 샷건
            //4.탄이 플레이어 주변을 도는 위성같은 무기
        }
    }
}
