using UnityEngine;

public class SurvivorsGameManager : MonoBehaviour
{
    [SerializeField] private SurvivorsPlayer player = null;
    [SerializeField] private SurvivorsMonsterSpawner spawner = null;
    [SerializeField] private SurvivorsHpBar playerHpBar = null;


    private void Update()
    {
        // 제일 가가까운 적찾아보기 
        // 쏠때만 적을 찾으면 됨
        // 

        SurvivorsMonster nearMonster =
            spawner.GetNearMonster(player.transform.position);
        if(nearMonster != null)
        {
            //플레이어한테 제일 가까운 타깃이 누구인지 알려주기
            player.SetTarget(nearMonster);
        }
        DisplayPlayerHp();
    }
    private void DisplayPlayerHp()
    {
        //언제 데미지를 받을지 모르니까 업데이트에서 계속 플레이어의 상태를 알아야함
        playerHpBar.SetHP(player.MaxHp, player.HP);
        playerHpBar.UpdatePosition(player.transform.position);

    }

}
