using System.Collections;
using UnityEngine;

public class SurvivorsWeaponBombProjectile : SurvivorsWeaponProjectileBase
{
    protected override IEnumerator MovingCoroutine()
    {
        yield return null;

        // float radius = transform.localScale.x * 0.5f;
        float radius = 10f;

        RaycastHit[] hits =
            Physics.SphereCastAll(
                transform.position, radius, Vector3.forward);
        if(hits != null && hits.Length> 0 )
        {
            foreach(RaycastHit hit in hits)
            {
                SurvivorsMonster monster =
                hit.transform.GetComponent<SurvivorsMonster>();
                if (monster != null) monster.Died();
            }
        }

        yield return null;
        Destroy(gameObject);
    }
}
