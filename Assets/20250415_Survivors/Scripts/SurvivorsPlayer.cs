using System.Collections;
using UnityEngine;

public class SurvivorsPlayer : MonoBehaviour
{
    private int maxHp = 10000;
    private int hp = 0;
    private float moveSpeed = 10f;

    private SurvivorsWeaponAttach weaponAttachPoint = null;
    private SurvivorsMonster target = null;

    public int MaxHp { get { return maxHp; } }
    public int HP { get { return hp; } }


    private void Awake()
    {
        weaponAttachPoint = GetComponentInChildren<SurvivorsWeaponAttach>();
    }

    private void Start()
    {
        hp = maxHp;
        StartCoroutine(ShootCoroutine());
    }
    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (target != null)
            {
                // 내가 쏠때 누구한테 쏠건지 모름 
                //weapon.Shoot(Vector3.zero);

                //Vector3 dir = target.transform.position - transform.position;
                //weapon.Shoot(dir.normalized);
                //어떤 무기든 간에 웨폰베이스만 있으면 됨
                if(target != null)
                {
                    weaponAttachPoint.Shoot(target.transform);
                    yield return new WaitForSeconds(weaponAttachPoint.ShootInterval);
                }
            }

            yield return null;
        }
    }
    private void Update()
    {
        Moving();
        LookAtMouse();
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Monster"))
        {
            SurvivorsMonster monster =
                _collider.GetComponent<SurvivorsMonster>();
            hp -= monster.Atk;
            if (hp < 0)//체력바가 넘어가기 때문에 0으로 맞춰듬
            {
                hp = 0;
                Debug.Log("YOU DIED!");
                Debug.Break();
            }
            monster.Died();
        }
        else if (_collider.CompareTag("Weapon"))
        {
            SurvivorsWeaponBase weapon =
                _collider.GetComponent<SurvivorsWeaponBase>();
            weaponAttachPoint.SetWeapon(weapon);
        }
    }
    private void Moving()
    {
        //입력은 따로 빼는게 나은 코드이지만 추가 시킴

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.position = transform.position +
            new Vector3(h, v, 0f) * moveSpeed * Time.deltaTime;
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
    public void SetTarget(SurvivorsMonster _target)
    {
        target = _target;
    }
}
