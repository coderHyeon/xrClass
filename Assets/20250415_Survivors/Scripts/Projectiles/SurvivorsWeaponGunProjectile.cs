using System.Collections;
using UnityEngine;

public class SurvivorsWeaponGunProjectile : SurvivorsWeaponProjectileBase
{
    private void Start()
    {
        moveSpeed =  10f;
        duration = 3f;

    }
    protected override IEnumerator MovingCoroutine()
    {

        while(true)
        {
            transform.position = transform.position + (moveDir * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
