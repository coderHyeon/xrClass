//using System.Collections;
//using UnityEngine;

//public class SurvivorsWeaponSinGunProjectile : SurvivorsWeaponProjectileBase
//{
//    private float sinDist = 3f;//폭
//    private void Start()
//    {
//        moveSpeed = 10f;
//        duration = 5f;

//    }
//    protected override IEnumerator MovingCoroutine()
//    {
//        //슛했던 위치
//        Vector3 shootPos = transform.position;
//        while(true)
//        {
//            transform.position = shootPos + new 
//                Vector3
//                (Mathf.Sin(Time.time * moveSpeed) * sinDist, 
//                0f, 
//                0f) ;
//            // 1. 앞으로 발사
//            // 2. 바라보는 방향으로 발사
//            yield return null;
//        }
//    }
//}




using System.Collections;
using UnityEngine;

public class SurvivorsWeaponSinGunProjectile : SurvivorsWeaponProjectileBase
{
    private float sinDist = 3f;//폭
    private void Start()
    {
        moveSpeed = 10f;
        duration = 5f;

    }

    private void Update()
    {
        LookAtMouse();
    }
    protected override IEnumerator MovingCoroutine()
    {
        //슛했던 위치
        Vector3 shootPos = transform.position; // attach point forward는 작동안함
        Vector3 worldToScreen = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mosePos = Input.mousePosition;
        Vector3 dir = mosePos - worldToScreen;
        Debug.Log("shootPos : " + shootPos);
        while (true)
        {
            transform.position = 
                new Vector3
                (0f,//h
                Mathf.Sin(Time.time * moveSpeed) * sinDist,  //v
                0f); //z
            Debug.Log("tr :" + transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //z는 사용을 안하고 있음 // 물체를 스크린으로 보내고 있으니깐

            transform.rotation =
                Quaternion.Euler(0f, 0f, angle - 90f);
            transform.position = (dir * moveSpeed * Time.deltaTime);

            // 1. 앞으로 발사
            // 2. 바라보는 방향으로 발사
            yield return null;
        }
    }
    private void LookAtMouse()
    {
        //내 위치를 스크린으로 
        Vector3 worldToScreen = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mosePos = Input.mousePosition;
        Vector3 dir = mosePos - worldToScreen;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //z는 사용을 안하고 있음 // 물체를 스크린으로 보내고 있으니깐

        transform.rotation =
            Quaternion.Euler(0f, 0f, angle - 90f);//수학에서의 0도와 유니티 0도는 다름
        //이전에는 플러스 앵글에 90도 지금은 회전 방향이 x인 피치이기 때문에 
    }
}






