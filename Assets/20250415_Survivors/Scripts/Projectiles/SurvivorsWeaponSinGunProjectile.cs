//using System.Collections;
//using UnityEngine;

//public class SurvivorsWeaponSinGunProjectile : SurvivorsWeaponProjectileBase
//{
//    private float sinDist = 3f;//��
//    private void Start()
//    {
//        moveSpeed = 10f;
//        duration = 5f;

//    }
//    protected override IEnumerator MovingCoroutine()
//    {
//        //���ߴ� ��ġ
//        Vector3 shootPos = transform.position;
//        while(true)
//        {
//            transform.position = shootPos + new 
//                Vector3
//                (Mathf.Sin(Time.time * moveSpeed) * sinDist, 
//                0f, 
//                0f) ;
//            // 1. ������ �߻�
//            // 2. �ٶ󺸴� �������� �߻�
//            yield return null;
//        }
//    }
//}




using System.Collections;
using UnityEngine;

public class SurvivorsWeaponSinGunProjectile : SurvivorsWeaponProjectileBase
{
    private float sinDist = 3f;//��
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
        //���ߴ� ��ġ
        Vector3 shootPos = transform.position; // attach point forward�� �۵�����
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
            //z�� ����� ���ϰ� ���� // ��ü�� ��ũ������ ������ �����ϱ�

            transform.rotation =
                Quaternion.Euler(0f, 0f, angle - 90f);
            transform.position = (dir * moveSpeed * Time.deltaTime);

            // 1. ������ �߻�
            // 2. �ٶ󺸴� �������� �߻�
            yield return null;
        }
    }
    private void LookAtMouse()
    {
        //�� ��ġ�� ��ũ������ 
        Vector3 worldToScreen = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mosePos = Input.mousePosition;
        Vector3 dir = mosePos - worldToScreen;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //z�� ����� ���ϰ� ���� // ��ü�� ��ũ������ ������ �����ϱ�

        transform.rotation =
            Quaternion.Euler(0f, 0f, angle - 90f);//���п����� 0���� ����Ƽ 0���� �ٸ�
        //�������� �÷��� �ޱۿ� 90�� ������ ȸ�� ������ x�� ��ġ�̱� ������ 
    }
}






