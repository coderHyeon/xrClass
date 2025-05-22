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
                // ���� �� �������� ����� �� 
                //weapon.Shoot(Vector3.zero);

                //Vector3 dir = target.transform.position - transform.position;
                //weapon.Shoot(dir.normalized);
                //� ����� ���� �������̽��� ������ ��
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
            if (hp < 0)//ü�¹ٰ� �Ѿ�� ������ 0���� �����
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
        //�Է��� ���� ���°� ���� �ڵ������� �߰� ��Ŵ

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.position = transform.position +
            new Vector3(h, v, 0f) * moveSpeed * Time.deltaTime;
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
    public void SetTarget(SurvivorsMonster _target)
    {
        target = _target;
    }
}
