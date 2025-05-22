using UnityEngine;

public class SurvivorsMonster : MonoBehaviour
{
    [SerializeField] private Color colorMinHp = Color.white;
    [SerializeField] private Color colorMaxHp = Color.white;
    [SerializeField] private Color colorMinAtk = Color.white;
    [SerializeField] private Color colorMaxAtk = Color.white;
    [SerializeField] private Color colorMinSpeed = Color.white;
    [SerializeField] private Color colorMaxSpeed = Color.white;

    private const int  HP_MIN = 1;
    private const int HP_MAX = 10;
    private const int  ATK_MIN = 1;
    private const int ATK_MAX = 5;
    private const float SPEED_MIN = 1f;
    private const float SPEED_MAX= 10f;


    private int hp = 0;
    private int atk = 0;
    private float moveSpeed = 0f;

    private MeshRenderer[] mrs = null;
    private Transform targetTr = null;

    private bool isInit = false;
    private bool isDead = false;

    public int Atk{get{ return atk; }}
    public bool IsDead { get { return isDead; } }

    public void Init(Transform _targetTr)
    {
        mrs = GetComponentsInChildren<MeshRenderer>();
        targetTr = _targetTr;

        hp = Random.Range(HP_MIN, HP_MAX+1);
        //float x = (float)(hp - HP_MIN) / (HP_MAX - HP_MIN) ;
        float hpRan = RandomInterpolation(hp, HP_MIN, HP_MAX);
        //Linear Interpolation
        mrs[0].material.color = Color.Lerp(colorMinHp, colorMaxHp, hpRan); //body

        
        atk = Random.Range(ATK_MIN, ATK_MAX+1); //int 자료형 오버로딩 --- 주의점!!! max수는 포함이안됨 이하가아니라 미만이었던거임~~
        float atkRan = RandomInterpolation(atk, ATK_MIN, ATK_MAX);
        mrs[1].material.color = Color.Lerp(colorMinAtk, colorMaxAtk, atkRan);
        mrs[2].material.color = Color.Lerp(colorMinAtk, colorMaxAtk, atkRan);

        moveSpeed = Random.Range(SPEED_MIN, SPEED_MAX); // float 자료형 오버로딩 실수는 이하임
        float moveSpeedRan = RandomInterpolation(moveSpeed, SPEED_MIN, SPEED_MAX);
        mrs[3].material.color = Color.Lerp(colorMinSpeed, colorMaxSpeed, moveSpeedRan);
        mrs[4].material.color = Color.Lerp(colorMinSpeed, colorMaxSpeed, moveSpeedRan);
        //위코드는 게으른 초기화임 
        isInit = true;
    }
    private void Update()
    {
        if (isInit == false || isDead == true) return;
        //플레이어가 있는 방향으로 무브스피드만 가면됨 이번에는 정규화를 해서 내속도록 따락다주면 됨

        Vector3 dir = targetTr.position - transform.position;
        dir.Normalize();

        transform.position =
            transform.position +
            (dir * moveSpeed * Time.deltaTime);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation =
        Quaternion.Euler(0f, 0f, angle - 90f);

    }// 프레임마다 계속 시작을 함

    public void OnTriggerEnter(Collider _collider)
    {
        if(_collider.CompareTag("Projectile"))
        {
            Destroy(_collider.gameObject);
            // Destroy(gameObject);
            // isDead = true;
            --hp;
            if (hp <= 0) isDead = true;
        }
    }

    public float RandomInterpolation(float _ranFloat,  float _min, float _max )
    {
        //float x = (hp - HP_MIN) / (HP_MAX - HP_MIN) 
        float randomInterpolation = (_ranFloat- _min) / (_max- _min);
        return randomInterpolation;
    }
    public void Died()
    {
        isDead = true;
    }
}
